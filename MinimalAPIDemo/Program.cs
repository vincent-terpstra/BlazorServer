using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.DbAccess;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>(
    //Note - this is created with dependency injection and default arguments
    //(service) => new SqlDataAccess(service.GetService<IConfiguration>()!)
    );
//builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseInMemoryDatabase("InMem")
);

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserService, UserServiceDb>();
builder.Services.AddMediatR(typeof(CreatePost));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.PopulateDbPosts();
    app.PopulateDbUsers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapUsersEndpoints();
app.MapPostEndpoints();


app.Run();