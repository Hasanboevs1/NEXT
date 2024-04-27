using Microsoft.EntityFrameworkCore;
using NEXT.Domain.Entities;

namespace NEXT.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }
    public DbSet<Post> Posts { get; set; }
}