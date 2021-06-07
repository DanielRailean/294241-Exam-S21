using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface ITeamService
    {
        Task<IList<Team>> GetAllTeams(int teamRank,string name);
        Task<Team> AddTeam(Team team);
    }
}