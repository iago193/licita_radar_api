using Microsoft.EntityFrameworkCore;
using LicitaRadarApi.Model;

namespace LicitaRadarApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
        });
    }
}