using Microsoft.EntityFrameworkCore;
using Magic.Domain;

namespace Magic.DAL;

public class QuestionsDbContext : DbContext
{
    public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }
}