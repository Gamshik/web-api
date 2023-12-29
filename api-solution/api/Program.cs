using cinemaApi.Extensions;
using cinemaApi.Middleware;
using cinemaBLL.Services;
using cinemaBLL.Validations;
using cinemaDAL.Context;
using cinemaDAL.Repositories;
using Entites.Models;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSwagger();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CinemaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection")));

builder.Services.ConfigureMapper();

builder.Services.AddAuthorization();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IValidator<Author>, AuthorValidator>();
builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

var app = builder.Build();

app.MigrateDatabase<CinemaContext>();
app.MigrateDatabase<UserContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();