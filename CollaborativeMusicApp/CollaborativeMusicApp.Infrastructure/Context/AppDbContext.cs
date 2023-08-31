using CollaborativeMusicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CollaborativeMusicApp.Infrastructure.Context;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<User> Users { get; set; } = null!;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}