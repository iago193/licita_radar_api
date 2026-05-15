using Microsoft.EntityFrameworkCore;
using licita_radar_api.Model;

namespace licita_radar_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}