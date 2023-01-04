using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class UserServiceDb : IUserService
{
    private readonly AppDbContext.AppDbContext _context;

    public UserServiceDb(AppDbContext.AppDbContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<PersonModel>> GetUsersAsync()
        => Task.FromResult<IEnumerable<PersonModel>>( _context.PersonModels);
    

    public Task<PersonModel?> GetUserAsync(int id)
        => _context.PersonModels.FirstOrDefaultAsync(model => model.Id == id);
    

    public async Task<PersonModel> InsertUserAsync(PersonModel person)
    {
        if (string.IsNullOrWhiteSpace(person.Firstname))
            throw new ArgumentException("Person requires a first name", "FirstName");
        
        if (string.IsNullOrWhiteSpace(person.Lastname))
            throw new ArgumentException("Person requires a last name", "LastName");

        _context.PersonModels.Add(person);
        await _context.SaveChangesAsync();

        return person;
    }

    public async Task UpdateUserAsync(PersonModel person)
    {
        _context.PersonModels.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var userToDelete = await _context.PersonModels.FirstOrDefaultAsync(model => model.Id == id);
        if (userToDelete is null)
            throw new KeyNotFoundException("cannot find user in database");

        _context.PersonModels.Remove(userToDelete);
        await _context.SaveChangesAsync();
    }
}