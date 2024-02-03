using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Data;
using System.Linq;
using TransferMarket.Business.Transfers.Commands;
using System;

namespace TransferMarket.Business.Transfers.Handlers
{
    public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public UpdateTransferCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            var transferToBeUpdated = _context.Transfers.FirstOrDefault(transfer => transfer.Id == request.Id);

            if (transferToBeUpdated == null)
            {
                return false;
            }

            transferToBeUpdated.TotalSum = request.TotalSum;

            UpdateHistoryTable(transferToBeUpdated);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Transfers.Transfer transfer)
        {
            _context.TransferHistories.Add(new Data.Models.Transfers.TransferHistory
            {
                TransferId = transfer.Id,
                NewTotalSum = transfer.TotalSum,
                Timestamp = DateTime.Now
            });
        }
    }
}
