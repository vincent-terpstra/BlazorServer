using DataAccess.DbAccess;
using Domain.Models;

namespace DataAccess.Services;

public class UserService : IUserService
{
    private readonly ISqlDataAccess _db;

    public UserService(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PersonModel>> GetUsersAsync()
        => _db.LoadDataAsync<PersonModel, dynamic>("user_getall", new{});

    public async Task<PersonModel?> GetUserAsync(int id)
        => (await _db.LoadDataAsync<PersonModel, dynamic>("user_get", new { id }))
        .FirstOrDefault();

    public async Task<PersonModel> InsertUserAsync(PersonModel person)
    {
        if (string.IsNullOrWhiteSpace(person.Firstname))
            throw new ArgumentException("Person requires a first name", "FirstName");
        
        if (string.IsNullOrWhiteSpace(person.Lastname))
            throw new ArgumentException("Person requires a last name", "LastName");
        
        await _db.SaveDataAsync("user_create", new {firstname = person.Firstname, lastname = person.Lastname});
        //HACK this doesn't update the Id of the person inserted
        return person;
    }
        
    
    public Task UpdateUserAsync(PersonModel person)
        => _db.SaveDataAsync("user_update", person);

    public Task DeleteUserAsync(int id)
        => _db.SaveDataAsync("user_delete", new { id });
}