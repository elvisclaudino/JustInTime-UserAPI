using JustInTimeUser.Domain.Entitities;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeUser.Infrastructure.DataAccess;
public class JustInTimeUserDbContext : DbContext
{
    public JustInTimeUserDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JustInTimeUserDbContext).Assembly);
    }
}

