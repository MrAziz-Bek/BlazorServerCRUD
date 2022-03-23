using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();

    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Name = "Half Life 2",
                Developer = "Valve",
                Release = new DateOnly(2004, 11, 16)
            },
            new Game
            {
                Id = 1,
                Name = "Day of the Tentacle",
                Developer = "Lucas Arts",
                Release = new DateOnly(1993, 5, 25)
            });
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}