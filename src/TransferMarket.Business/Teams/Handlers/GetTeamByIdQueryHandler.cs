using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Teams.Models;
using TransferMarket.Business.Teams.Queries;
using TransferMarket.Data;

namespace TransferMarket.Business.Teams.Handlers
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Team>
    {
        private readonly TransferMarketContext _context;

        public GetTeamByIdQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Teams
                .FirstOrDefaultAsync(team => team.Id == request.Id, cancellationToken: cancellationToken);

            if (result == null) { return null; }

            return new Team
            {
                Id = result.Id,
                Name = result.Name,
                City = result.City,
                League = result.League,
                Budget = result.Budget,
                TotalValue = result.TotalValue,
            };
        }
    }
}
