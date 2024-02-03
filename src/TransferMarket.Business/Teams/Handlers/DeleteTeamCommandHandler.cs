using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Data;
using TransferMarket.Business.Teams.Commands;
using System.Linq;

namespace TransferMarket.Business.Teams.Handlers
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public DeleteTeamCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var teamToBeDeleted = _context.Teams.FirstOrDefault(team => team.Id == request.Id);

            if (teamToBeDeleted == null)
            {
                return false;
            }

            _context.Teams.Remove(teamToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}