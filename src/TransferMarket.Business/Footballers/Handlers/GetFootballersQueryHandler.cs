using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Business.Footballers.Queries;
using TransferMarket.Business.Footballers.Models;
using TransferMarket.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class GetFootballersQueryHandler : IRequestHandler<GetFootballersQuery, IEnumerable<Footballer>>
    {
        private readonly TransferMarketContext _context;

        public GetFootballersQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Footballer>> Handle(GetFootballersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Footballers
                .Select(footballer => new Footballer
                {
                    Id = footballer.Id,
                    Name = footballer.Name,
                    Position = footballer.Position,
                    Height = footballer.Height,
                    Weight = footballer.Weight,
                    Wage = footballer.Wage
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
