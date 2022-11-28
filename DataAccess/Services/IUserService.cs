using Domain.Models;

namespace DataAccess.Services;

public interface IUserService
{
    Task<IEnumerable<PersonModel>> GetUsersAsync();
    Task<PersonModel?> GetUserAsync(int id);
    Task InsertUserAsync(PersonModel person);
    Task UpdateUserAsync(PersonModel person);
    Task DeleteUserAsync(int id);
}