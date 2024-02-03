using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Business.Teams.Models;
using TransferMarket.Business.Teams.Queries;

namespace TransferMarket.Business.Teams.Handlers
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IEnumerable<Team>>
    {
        private readonly TransferMarketContext _context;

        public GetTeamsQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Teams
                .Select(team => new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    City = team.City,
                    League = team.League,
                    Budget = team.Budget,
                    TotalValue = team.TotalValue
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
