using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Magic.DAL;

public class SampleContextFactory : IDesignTimeDbContextFactory<MagicDbContext>
{
    public MagicDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MagicDbContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.DAL.json");
        IConfigurationRoot config = builder.Build();

        string connectionString = config.GetSection("Database:ConnectionString").Value;
        optionsBuilder.UseNpgsql(connectionString);
        return new MagicDbContext(optionsBuilder.Options);
    }
}