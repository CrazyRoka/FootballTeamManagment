using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballTeamManagment.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> Index()
        {
            return await _teamService.GetAllAsync();
        }

        [HttpGet("{id}", Name = "TeamLink")]
        public async Task<IActionResult> Details(int id)
        {
            var team = await _teamService.GetAsync(id);
            if(team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamInput teamInput)
        {
            var team = _mapper.Map<Team>(teamInput);
            var createdTeam = await _teamService.CreateAsync(team);
            if(createdTeam == null)
            {
                return BadRequest(new { message = "Name already exist" });
            }
            return CreatedAtRoute(
                routeName: "TeamLink",
                routeValues: new { id = createdTeam.Id },
                value: createdTeam );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TeamInput teamInput)
        {
            if (ModelState.IsValid)
            {
                var team = _mapper.Map<Team>(teamInput);
                team.Id = id;
                team = await _teamService.UpdateAsync(team);
                if(team == null)
                {
                    return BadRequest("Can't update");
                }
                return Ok(team);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.RemoveAsync(id);
            return NoContent();
        }
    }
}
