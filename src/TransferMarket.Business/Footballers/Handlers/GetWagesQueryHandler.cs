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
    public class GetWagesQueryHandler : IRequestHandler<GetWagesQuery, WageReport>
    {
        private readonly TransferMarketContext _context;

        public GetWagesQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<WageReport> Handle(GetWagesQuery request, CancellationToken cancellationToken)
        {
            var wagesThroughoutTime = await _context.FootballerHistories
                .Where(fh => fh.FootballerId == request.Id)
                .Select(fh => new Wage { Value = fh.NewWage, Timestamp = fh.Timestamp.TrimMilliseconds()})
                .ToListAsync(cancellationToken: cancellationToken);

            return new WageReport { WageThroughoutTime = wagesThroughoutTime };
        }
    }
}
