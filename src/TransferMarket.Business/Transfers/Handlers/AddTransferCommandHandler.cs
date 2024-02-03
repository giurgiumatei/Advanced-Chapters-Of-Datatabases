using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Transfers.Commands;
using TransferMarket.Data;

namespace TransferMarket.Business.Transfers.Handlers
{
    public class AddTransferCommandHandler : IRequestHandler<AddTransferCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public AddTransferCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTransferCommand request, CancellationToken cancellationToken)
        {
            var newTransfer = new Data.Models.Transfers.Transfer
            {
                FootballerId = request.FootballerId,
                TeamId = request.TeamId,
                TotalSum = request.TotalSum
            };

            _context.Transfers.Add(newTransfer);

            UpdateHistoryTable(newTransfer);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Transfers.Transfer transfer)
        {
            _context.TransferHistories.Add(new Data.Models.Transfers.TransferHistory
            {
                Transfer = transfer,
                NewTotalSum = transfer.TotalSum,
                Timestamp = DateTime.Now
            });
        }
    }
}
