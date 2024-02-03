using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Business.Teams.Commands;
using TransferMarket.Data;
using System.Linq;
using System;

namespace TransferMarket.Business.Teams.Handlers
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public UpdateTeamCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var teamToBeUpdated = _context.Teams.FirstOrDefault(team => team.Id == request.Id);

            if (teamToBeUpdated == null)
            {
                return false;
            }
            teamToBeUpdated.Name = request.Name;
            teamToBeUpdated.Budget = request.Budget;
            teamToBeUpdated.City = request.City;
            teamToBeUpdated.League = request.League;
            teamToBeUpdated.TotalValue = request.TotalValue;

            UpdateHistoryTable(teamToBeUpdated);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Teams.Team team)
        {
            _context.TeamHistories.Add(new Data.Models.Teams.TeamHistory
            {
                TeamId = team.Id,
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
