using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Business.Transfers.Queries;
using TransferMarket.Business.Transfers.Models;

namespace TransferMarket.Business.Transfers.Handlers
{
    public class GetTransfersQueryHandler : IRequestHandler<GetTransfersQuery, IEnumerable<Transfer>>
    {
        private readonly TransferMarketContext _context;

        public GetTransfersQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transfer>> Handle(GetTransfersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Transfers
                .Select(transfer => new Transfer
                {
                    Id = transfer.Id,
                    FootballerId = transfer.FootballerId,
                    TeamId = transfer.TeamId,
                    TotalSum = transfer.TotalSum
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
