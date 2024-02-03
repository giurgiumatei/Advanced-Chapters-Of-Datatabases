using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Transfers.Models;
using TransferMarket.Business.Transfers.Queries;
using TransferMarket.Data;

namespace TransferMarket.Business.Transfers.Handlers
{
    public class GetTransferByIdQueryHandler : IRequestHandler<GetTransferByIdQuery, Transfer>
    {
        private readonly TransferMarketContext _context;

        public GetTransferByIdQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<Transfer> Handle(GetTransferByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Transfers
                .FirstOrDefaultAsync(team => team.Id == request.Id, cancellationToken: cancellationToken);

            if (result == null) { return null; }

            return new Transfer
            {
                Id = result.Id,
                FootballerId = result.FootballerId,
                TeamId = result.TeamId,
                TotalSum = result.TotalSum
            };
        }
    }
}
