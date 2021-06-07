using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerServiceAPI PlayerService;

        public PlayerController(IPlayerServiceAPI playerService)
        {
            PlayerService = playerService;
        }
        
        [HttpDelete]
        public async Task<ActionResult<Player>> GetAllTeams([FromQuery]int playerId)
        {
            try
            {
                Player valid = await PlayerService.DeletePlayer(playerId);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("{teamName}")]
        public async Task<ActionResult<Team>> AddPlayer([FromRoute] string teamName,[FromBody] Player player)
        {
            // implicitly validated but you can use "ModelState.IsValid" to check if valid as below
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Player valid = await PlayerService.AddPlayer(teamName,player);
                return Ok(valid);
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}