using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ITeamServiceAPI
    {
        Task<Team> AddTeam(Team team);
        Task<IList<Team>> GetTeams(int minRating, string name);
    }
}