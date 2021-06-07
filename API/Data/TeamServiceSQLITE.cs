using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DB;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TeamServiceSqlite: ITeamServiceAPI
    {
        private FootballContext dbContext;

        public TeamServiceSqlite(FootballContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Team> AddTeam(Team team)
        {
            await dbContext.Teams.AddAsync(team);
            await dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<IList<Team>> GetTeams(int minRating, string name)
        {
            if (minRating == 0 && name==null)
            {
                return await dbContext.Teams.ToListAsync();
            }

            if (minRating == 0)
            {
                return dbContext.Teams.Where(t=>t.TeamName.Contains(name)).ToList();
            }

            if (name==null)
            {
               return dbContext.Teams.Where(t => t.Ranking >= minRating).ToList();
            }
            IList<Team> returned = dbContext.Teams.Where(t => t.Ranking >= minRating).Where(t=>t.TeamName.Contains(name)).ToList();
            Console.WriteLine("min"+minRating);
            Console.WriteLine("name"+name);
            return returned;
        }
    }
}