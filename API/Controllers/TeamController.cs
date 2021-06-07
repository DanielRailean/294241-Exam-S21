using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private ITeamServiceAPI TeamService;

        public TeamController(ITeamServiceAPI teamService)
        {
            TeamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Team>>> GetAllTeams([FromQuery]int minRating,[FromQuery] string name)
        {
            try
            {
                IList<Team> valid = await TeamService.GetTeams(minRating,name);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Team>> AddTeam([FromBody] Team team)
        {
            // implicitly validated but you can use "ModelState.IsValid" to check if valid as below
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Team valid = await TeamService.AddTeam(team);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
                
            }
        }
    }
}