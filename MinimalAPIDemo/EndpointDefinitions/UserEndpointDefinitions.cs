using Autofac.Core;
using MinimalAPIDemo.Abstractions;

namespace MinimalAPIDemo;

public class UserEndpointDefinitions : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPut("/users", CreateUser);
        app.MapPost("/users", UpdateUser);
        app.MapDelete("/users", DeleteUser);
    }

    private async Task<IResult> GetUsers(IUserService data)
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

    private async Task<IResult> GetUser(int id, IUserService service)
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

    private async Task<IResult> CreateUser(PersonModel model, IUserService service)
    {
        try
        {
            await service.InsertUserAsync(new PersonModel() {Firstname = model.Firstname, Lastname = model.Lastname, Email = model.Email});
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private async Task<IResult> UpdateUser(PersonModel person, IUserService service)
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

    private async Task<IResult> DeleteUser(int id, IUserService service)
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