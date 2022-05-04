using CA.Domain.Auth;
using CA.Domain.Entities;
using CA.Domain.Middlewares;
using CA.Domain.RepositoryInterfaces;
using CA.Persistence.Context;
using CA.Persistence.EFRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//Context
builder.Services.AddDbContext<AuctionContext>(context => context.UseSqlServer(builder.Configuration["connectionStrings:DatabaseConnection"]));

//Repositories and abstractions
builder.Services.AddScoped<ILotsRepository, LotsEFRepository>();
builder.Services.AddScoped<ICarsRepository, CarsEFRepository>();
builder.Services.AddScoped<IAuctionsRepository, AuctionsEFRepository>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsEFRepository>();
builder.Services.AddScoped<IBidsRepository, BidsEFRepository>();

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

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(options =>
     {
         options.SaveToken = true;
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,

             ValidIssuer = TokenConfiguration.Issuer,
             ValidAudience = TokenConfiguration.Audience,
             IssuerSigningKey = TokenConfiguration.GetKey()
         };
     });

//Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuctionPolicies.DefaultRights, policy =>
        policy.RequireRole(AuctionRoles.DefaultUser));

    options.AddPolicy(AuctionPolicies.ElevatedRights, policy =>
        policy.RequireRole(AuctionRoles.Administrator));
});

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

app.UseAuthentication();
app.UseAuthorization();

//Middlewares
app.UseMiddleware<ExceptionsHandlingMiddleware>();

app.MapControllers();

app.Run();
