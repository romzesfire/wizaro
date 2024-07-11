using Microsoft.EntityFrameworkCore;
using Magic.Domain;

namespace Magic.DAL;

public class MagicDbContext : DbContext
{
    public MagicDbContext(DbContextOptions<MagicDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}