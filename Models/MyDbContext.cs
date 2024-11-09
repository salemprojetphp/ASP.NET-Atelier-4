using Microsoft.EntityFrameworkCore;
using _.Models;
namespace _.Models;

public class MyDbContext : DbContext
{
    private readonly string _connectionString;
    public DbSet<Movie>? movies { get; set; }
    public DbSet<Genre> genres { get; set; }
    public MyDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

}