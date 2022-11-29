using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.DbAccess;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDemo.Abstractions;

namespace MinimalAPIDemo;

public static class MinimalAPIExtensionMethods
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>(
            //Note - this is created with dependency injection and default arguments
            //(service) => new SqlDataAccess(service.GetService<IConfiguration>()!)
        );

        builder.Services.AddDbContext<AppDbContext>(
            opt => opt.UseInMemoryDatabase("InMem")
        );

        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IUserService, UserServiceDb>();
        builder.Services.AddMediatR(typeof(CreatePost));
    }

    public static void RegisterEndpoints(this WebApplication app)
    {
        var endPointDefinitons = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (IEndpointDefinition endpoint in endPointDefinitons)
        {
            endpoint.RegisterEndpoints(app);
        }
    }
}