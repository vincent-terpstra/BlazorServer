using Application.Abstractions;
using DataAccess;

namespace MinimalAPIDemo;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.RegisterServices();

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            var scope = app.Services.CreateScope();
            var users = scope.ServiceProvider.GetRequiredService<IUserService>();
            users.PopulateDbUsers();

            var posts = scope.ServiceProvider.GetRequiredService<IPostRepository>();
            posts.PopulateDbPosts();

        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.RegisterExceptionHandling();
        app.RegisterEndpoints();

        app.Run();
    }
}