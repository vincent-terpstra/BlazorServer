using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    public DbSet<Post> Posts { get; set; } = null!;

    public DbSet<PersonModel> PersonModels { get; set; } = null!;
}