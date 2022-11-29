using Application.Abstractions;

namespace MinimalAPIDemo;

public static class PopulateDb
{
    public static void PopulateDbPosts(this IApplicationBuilder app)
    {
        Task.Run(async () =>
        {
           var scopedContext = app.ApplicationServices.CreateScope();
            var posts = scopedContext.ServiceProvider.GetService<IPostRepository>()!;
            var allPosts = await posts.GetAllPosts();

            if (allPosts.Any() is false)
            {
                await posts.CreatePost(new Post() {Content = "Hello World"});
                await posts.CreatePost(new Post() {Content = "42 is the answer"});
            }
        }).Wait();
    }
    
    public static void PopulateDbUsers(this IApplicationBuilder app)
        {
            Task.Run(async () =>
            {
               var scopedContext = app.ApplicationServices.CreateScope();
                var posts = scopedContext.ServiceProvider.GetService<IUserService>()!;
                var allPosts = await posts.GetUsersAsync();
    
                if (allPosts.Any() is false)
                {
                    await posts.InsertUserAsync(new PersonModel()
                    {
                        Email = "vdterp@email.com",
                        Firstname = "FirstName",
                        Lastname = "LastName"
                    });
                }
            }).Wait();
        }
}