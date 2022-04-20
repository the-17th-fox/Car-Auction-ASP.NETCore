using CA.Domain.GlobalExceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CA.Domain.Middlewares
{
    public class ExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exeption)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = exeption switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,

                    InvalidCredentialsException => (int)HttpStatusCode.Unauthorized,

                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var exeptionResponse = new
                {
                    message = exeption.Message,
                    statusCode = response.StatusCode
                };

                var result = JsonSerializer.Serialize(exeptionResponse);
                await response.WriteAsync(result);
            }
        }

    }
}
