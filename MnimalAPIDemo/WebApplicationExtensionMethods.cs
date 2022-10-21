using Autofac.Core;

namespace MnimalAPIDemo;

public static class WebAppExtensionMethods
{
    public static void ConfigureApi(this WebApplication application)
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
            return Results.Ok(await data.GetUsers());
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
            var results = await service.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> CreateUser(UserModel model, IUserService service)
    {
        try
        {
            await service.InsertUser(new UserModel() {FirstName = model.FirstName, LastName = model.LastName});
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUser(UserModel user, IUserService service)
    {
        try
        {
            await service.UpdateUser(user);
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
            await service.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}