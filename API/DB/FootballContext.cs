using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class FootballContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Football.db");
        }
    }
}