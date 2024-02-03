using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferMarket.Business.Teams.Commands;
using TransferMarket.Business.Teams.Queries;
using TransferMarket.Data.Models.Teams;

namespace TransferMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Teams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var result = await _mediator.Send(new GetTeamsQuery());

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<Team>> GetTeam(int TeamId)
        {
            var result = await _mediator.Send(new GetTeamByIdQuery { Id = TeamId });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddTeam([FromBody] AddTeamCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateTeam([FromBody] UpdateTeamCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTeam(int TeamId)
        {
            var result = await _mediator.Send(
                new DeleteTeamCommand
                {
                    Id = TeamId
                }
            );

            return Ok(result);
        }
    }
}
