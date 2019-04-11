using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using FootballTeamManagment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SnowboardsController : Controller
    {
        private readonly IEntityService<Snowboard> _service;
        private readonly IMapper _mapper;
        public SnowboardsController(IEntityService<Snowboard> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SnowboardView>> Index()
        {
            var snowboards = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SnowboardView>>(snowboards);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]SnowboardView view)
        {
            if (ModelState.IsValid)
            {
                var snowboard = _mapper.Map<Snowboard>(view);
                snowboard.Id = id;
                snowboard = await _service.UpdateAsync(snowboard);
                if(snowboard == null)
                {
                    return BadRequest("Can't update");
                }
                view = _mapper.Map<SnowboardView>(snowboard);
                return Ok(view);
            }
            return BadRequest(ModelState);
        }
    }
}
