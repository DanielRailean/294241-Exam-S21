using System;
using System.Linq;
using System.Threading.Tasks;
using API.DB;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PlayerServiceSqlite : IPlayerServiceAPI
    {
        private FootballContext dbContext;

        public PlayerServiceSqlite(FootballContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Player> AddPlayer(string teamName, Player player)
        {
            Team playerTeam = await dbContext.Teams.Include(t=>t.Players).FirstAsync(t => t.TeamName.Equals(teamName));
            if (playerTeam != null)
            {
                player.TeamRefTeamName = teamName;
                dbContext.Add(player);
                await dbContext.SaveChangesAsync();
            }

            return player;
        }

        public async Task<Player> DeletePlayer(int playerId)
        {
            Player toDelete = await dbContext.Players.FirstAsync(p => p.Id == playerId);
            if (toDelete != null)
            {
                dbContext.Players.Remove(toDelete);
                await dbContext.SaveChangesAsync();
            }

            return toDelete;
        }
    }
}