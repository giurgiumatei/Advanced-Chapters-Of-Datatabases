using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Extensions;
using TransferMarket.Business.Footballers.Models;
using TransferMarket.Business.Footballers.Queries;
using TransferMarket.Data;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class GetFootballerStateQueryAtGivenTimeHandler : IRequestHandler<GetFootballerStateAtGivenTimeQuery, FootballerState>
    {
        private readonly TransferMarketContext _context;

        public GetFootballerStateQueryAtGivenTimeHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<FootballerState> Handle(GetFootballerStateAtGivenTimeQuery request, CancellationToken cancellationToken)
        {
            var result = (await _context.FootballerHistories
                .ToListAsync())
                .Where(fh => fh.FootballerId == request.Id && fh.Timestamp.TrimMilliseconds() == request.Time.TrimMilliseconds())
                .FirstOrDefault();

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
