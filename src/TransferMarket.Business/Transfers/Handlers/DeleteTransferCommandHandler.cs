using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Data;
using System.Linq;
using TransferMarket.Business.Transfers.Commands;

namespace TransferMarket.Business.Transfers.Handlers
{
    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public DeleteTransferCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            var transferToBeDeleted = _context.Transfers.FirstOrDefault(transfer => transfer.Id == request.Id);

            if (transferToBeDeleted == null)
            {
                return false;
            }

            _context.Transfers.Remove(transferToBeDeleted);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}