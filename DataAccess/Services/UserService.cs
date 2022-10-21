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

    public Task<IEnumerable<UserModel>> GetUsers()
        => _db.LoadData<UserModel, dynamic>("user_getall", new{});

    public async Task<UserModel?> GetUser(int id)
        => (await _db.LoadData<UserModel, dynamic>("user_get", new { id }))
        .FirstOrDefault();

    public Task InsertUser(UserModel user)
        => _db.SaveData("user_create", new {user.FirstName, user.LastName});
    
    public Task UpdateUser(UserModel user)
        => _db.SaveData("user_update", user);

    public Task DeleteUser(int id)
        => _db.SaveData("user_delete", new { id });
}