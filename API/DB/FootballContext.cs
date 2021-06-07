using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DB
{
    public class FootballContext : DbContext
    {
        public DbSet<Player> Players;
        public DbSet<Team> Teams;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Football.db");
        }
    }
}