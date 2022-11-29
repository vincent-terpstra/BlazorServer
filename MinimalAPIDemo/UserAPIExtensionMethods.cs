using Autofac.Core;

namespace MinimalAPIDemo;

public static class WebAppExtensionMethods
{
    public static void ConfigureUsersApi(this WebApplication application)
    {
        application.MapGet("/Users", GetUsers);
        application.MapGet("/Users/{id}", GetUser);
        application.MapPut("/Users", CreateUser);
        application.MapPost("/Users", UpdateUser);
        application.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserService data)
    {
        try
        {
            return Results.Ok(await data.GetUsersAsync());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserService service)
    {
        try
        {
            var results = await service.GetUserAsync(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> CreateUser(PersonModel model, IUserService service)
    {
        try
        {
            await service.InsertUserAsync(new PersonModel() {Firstname = model.Firstname, Lastname = model.Lastname});
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUser(PersonModel person, IUserService service)
    {
        try
        {
            await service.UpdateUserAsync(person);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserService service)
    {
        try
        {
            await service.DeleteUserAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}