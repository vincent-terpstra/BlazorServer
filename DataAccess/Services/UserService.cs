using DataAccess.DbAccess;
using DataAccess.Models;

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

    public async Task InsertUserAsync(PersonModel person)
    {
        if (string.IsNullOrWhiteSpace(person.firstname))
            throw new ArgumentException("Person requires a first name", "FirstName");
        
        if (string.IsNullOrWhiteSpace(person.lastname))
            throw new ArgumentException("Person requires a last name", "LastName");
        
        await _db.SaveDataAsync("user_create", new {person.firstname, person.lastname});
    }
        
    
    public Task UpdateUserAsync(PersonModel person)
        => _db.SaveDataAsync("user_update", person);

    public Task DeleteUserAsync(int id)
        => _db.SaveDataAsync("user_delete", new { id });
}