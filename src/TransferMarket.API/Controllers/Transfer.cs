using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferMarket.Business.Transfers.Commands;
using TransferMarket.Business.Transfers.Queries;
using TransferMarket.Data.Models.Transfers;

namespace TransferMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Transfers")]
        public async Task<ActionResult<IEnumerable<Transfer>>> GetTransfers()
        {
            var result = await _mediator.Send(new GetTransfersQuery());

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<Transfer>> GetTransfer(int TransferId)
        {
            var result = await _mediator.Send(new GetTransferByIdQuery { Id = TransferId });

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddTransfer([FromBody] AddTransferCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateTransfer([FromBody] UpdateTransferCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTransfer(int TransferId)
        {
            var result = await _mediator.Send(
                new DeleteTransferCommand
                {
                    Id = TransferId
                }
            );

            return Ok(result);
        }
    }
}
