using Application.Abstractions;
using DataAccess.Services;
using Domain.Models;

namespace DataAccess;

public static class PopulateDb
{
    public static void PopulateDbPosts(this IPostRepository posts)
    {
        Task.Run(async () =>
        {
            var allPosts = await posts.GetAllPosts();

            if (allPosts.Any() is false)
            {
                await posts.CreatePost(new Post() {Content = "Hello World"});
                await posts.CreatePost(new Post() {Content = "42 is the answer"});
            }
        }).Wait();
    }
    
    public static void PopulateDbUsers(this IUserService users)
        {
            Task.Run(async () =>
            {
                var allPosts = await users.GetUsersAsync();
    
                if (allPosts.Any() is false)
                {
                    await users.InsertUserAsync(new PersonModel()
                    {
                        Email = "hello@email.com",
                        Firstname = "Hello",
                        Lastname = "World"
                    });
                }
            }).Wait();
        }
}