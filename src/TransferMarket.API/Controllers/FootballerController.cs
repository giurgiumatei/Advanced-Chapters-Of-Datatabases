using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferMarket.Business.Footballers.Commands;
using TransferMarket.Business.Footballers.Models;
using TransferMarket.Business.Footballers.Queries;
using Footballer = TransferMarket.Business.Footballers.Models.Footballer;

namespace TransferMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FootballerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("footballers")]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            var result = await _mediator.Send(new GetFootballersQuery());

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<Footballer>> GetFootballer(int footballerId)
        {
            var result = await _mediator.Send(new GetFootballerByIdQuery { Id = footballerId });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-current-state")]
        public async Task<ActionResult<FootballerState>> GetFootballerState(int footballerId)
        {
            var result = await _mediator.Send(new GetFootballerStateQuery { Id = footballerId });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-state-at-given-time")]
        public async Task<ActionResult<FootballerState>> GetFootballerStateAtGivenTime(int footballerId, DateTime time)
        {
            var result = await _mediator.Send(new GetFootballerStateAtGivenTimeQuery 
            {
                Id = footballerId,
                Time = time
            });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-maximum-wage-period")]
        public async Task<ActionResult<MaximumWagePeriod>> GetMaximumWagePeriod(int footballerId)
        {
            var result = await _mediator.Send(new GetMaximumWagePeriodQuery
            {
                Id = footballerId,
            });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-wages-throughout-time")]
        public async Task<ActionResult<WageReport>> GetWagesTroughoutTime(int footballerId)
        {
            var result = await _mediator.Send(new GetWagesQuery
            {
                Id = footballerId,
            });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddFootballer([FromBody] AddFootballerCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateFootballer([FromBody] UpdateFootballerCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteFootballer(int footballerId)
        {
            var result = await _mediator.Send(
                new DeleteFootballerCommand
                {
                    Id = footballerId
                }
            );

            return Ok(result);
        }
    }
}
