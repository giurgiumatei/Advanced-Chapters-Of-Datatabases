using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Teams.Commands;
using TransferMarket.Data;

namespace TransferMarket.Business.Teams.Handlers
{
    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public AddTeamCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            var newTeam = new Data.Models.Teams.Team
            {
                Name = request.Name,
                Budget = request.Budget,
                City = request.City,
                League = request.League,
                TotalValue = request.TotalValue
            };

            _context.Teams.Add(newTeam);

            UpdateHistoryTable(newTeam);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Teams.Team team)
        {
            _context.TeamHistories.Add(new Data.Models.Teams.TeamHistory
            {
                Team = team,
                NewBudget = team.Budget,
                NewCity = team.City,
                NewLeague = team.League,
                NewName = team.Name,
                NewTotalValue = team.TotalValue,
                Timestamp = DateTime.Now
            });
        }
    }
}
