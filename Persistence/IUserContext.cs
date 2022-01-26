using Microsoft.EntityFrameworkCore;

namespace SimpleAuth.Persistence;

public interface IUserContext
{
    public DbSet<User> Users { get; set; }
}
