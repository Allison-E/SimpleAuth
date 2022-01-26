using Microsoft.EntityFrameworkCore;

namespace SimpleAuth.Persistence;

public class UserContext : DbContext, IUserContext
{
    public DbSet<User> Users { get; set; }

    public UserContext(DbContextOptions<UserContext> dbContextOptions) : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
    }
}
