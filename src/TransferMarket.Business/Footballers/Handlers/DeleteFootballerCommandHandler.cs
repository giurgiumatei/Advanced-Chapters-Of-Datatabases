using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Footballers.Commands;
using TransferMarket.Data;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class DeleteFootballerCommandHandler : IRequestHandler<DeleteFootballerCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public DeleteFootballerCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFootballerCommand request, CancellationToken cancellationToken)
        {
            var footballerToBeDeleted = _context.Footballers
            .FirstOrDefault(footballer => footballer.Id == request.Id);

            if (footballerToBeDeleted == null)
            {
                return false;
            }

            _context.Footballers.Remove(footballerToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
