using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Footballers.Models;
using TransferMarket.Business.Footballers.Queries;
using TransferMarket.Data;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class GetFootballerStateQueryHandler : IRequestHandler<GetFootballerStateQuery, FootballerState>
    {
        private readonly TransferMarketContext _context;

        public GetFootballerStateQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<FootballerState> Handle(GetFootballerStateQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FootballerHistories
                .Where(fh => fh.FootballerId == request.Id)
                .OrderByDescending(f => f.Timestamp)
                .FirstOrDefaultAsync();

            if (result == null) { return null; }

            return new FootballerState
            {
                Name = result.NewName,
                Height = result.NewHeight,
                Weight = result.NewWeight,
                Position = result.NewPosition,
                Wage = result.NewWage
            };
        }
    }
}
