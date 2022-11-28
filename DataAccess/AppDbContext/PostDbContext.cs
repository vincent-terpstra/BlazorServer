using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class PostDbContext : DbContext
{
    public PostDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    
    public DbSet<Post> Posts { get; set; }
}