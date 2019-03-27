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
    public class FootballPlayersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEntityService<FootballPlayer> _service;
        public FootballPlayersController(IMapper mapper, IEntityService<FootballPlayer> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<FootballPlayerView>> Index()
        {
            var players = await _service.GetAllAsync();
            var playerViews = _mapper.Map<IEnumerable<FootballPlayerView>>(players);
            return playerViews;
        }

        [HttpGet("{id}", Name = "PlayerLink")]
        public async Task<IActionResult> Details(int id)
        {
            var player = await _service.GetAsync(id);
            if(player == null)
            {
                return NotFound();
            }
            var view = _mapper.Map<FootballPlayerView>(player);
            return Ok(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]FootballPlayerView playerView)
        {
            var player = _mapper.Map<FootballPlayer>(playerView);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPlayer = await _service.CreateAsync(player);
            if (createdPlayer == null)
            {
                return BadRequest(new { message = "Can't create" });
            }

            var view = _mapper.Map<FootballPlayerView>(createdPlayer);
            return CreatedAtRoute(
                routeName: "PlayerLink",
                routeValues: new { id = createdPlayer.Id },
                value: view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]FootballPlayerView playerView)
        {
            if (ModelState.IsValid)
            {
                var player = _mapper.Map<FootballPlayer>(playerView);
                player.Id = id;
                player = await _service.UpdateAsync(player);
                if (player == null)
                {
                    return BadRequest("Can't update");
                }
                var view = _mapper.Map<FootballPlayerView>(player);
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
