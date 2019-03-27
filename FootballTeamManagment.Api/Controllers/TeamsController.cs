using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballTeamManagment.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeamsController : Controller
    {
        private readonly IEntityService<Team> _service;
        private readonly IMapper _mapper;
        public TeamsController(IEntityService<Team> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<TeamView>> Index()
        {
            var teams = await _service.GetAllAsync();
            var view = _mapper.Map<IEnumerable<TeamView>>(teams);
            return view;
        }

        [HttpGet("{id}", Name = "TeamLink")]
        public async Task<IActionResult> Details(int id)
        {
            var team = await _service.GetAsync(id);
            if(team == null)
            {
                return NotFound();
            }
            var view = _mapper.Map<TeamView>(team);
            return Ok(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TeamView teamInput)
        {
            var team = _mapper.Map<Team>(teamInput);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTeam = await _service.CreateAsync(team);
            if(createdTeam == null)
            {
                return BadRequest(new { message = "Can't create" });
            }

            var view = _mapper.Map<TeamView>(createdTeam);
            return CreatedAtRoute(
                routeName: "TeamLink",
                routeValues: new { id = view.Id },
                value: view );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]TeamView teamView)
        {
            if (ModelState.IsValid)
            {
                var team = _mapper.Map<Team>(teamView);
                team.Id = id;
                team = await _service.UpdateAsync(team);
                if(team == null)
                {
                    return BadRequest("Can't update");
                }
                var view = _mapper.Map<TeamView>(team);
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }
    }
}
