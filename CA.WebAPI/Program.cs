using CA.Domain.Entities;
using CA.Domain.Middlewares;
using CA.Domain.RepositoryInterfaces;
using CA.Persistence.Context;
using CA.Persistence.EFRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Context
builder.Services.AddDbContext<AuctionContext>(context => context.UseSqlServer(builder.Configuration["connectionStrings:DatabaseConnection"]));

//Identity
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AuctionContext>();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Middlewares
app.UseMiddleware<ExceptionsHandlingMiddleware>();

app.MapControllers();

app.Run();
