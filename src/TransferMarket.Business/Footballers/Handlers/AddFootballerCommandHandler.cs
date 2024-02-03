using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Footballers.Commands;
using TransferMarket.Data;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class AddFootballerCommandHandler : IRequestHandler<AddFootballerCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public AddFootballerCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddFootballerCommand request, CancellationToken cancellationToken)
        {
            var newFootballer = new Data.Models.Footballers.Footballer
            {
                Name = request.Name,
                Wage = request.Wage,
                Weight = request.Weight,
                Height = request.Height,
                Position = request.Position,
            };

            _context.Footballers.Add(newFootballer);

            UpdateHistoryTable(newFootballer);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Footballers.Footballer footballer)
        {
            _context.FootballerHistories.Add(new Data.Models.Footballers.FootballerHistory
            {
                Footballer = footballer,
                NewHeight = footballer.Weight,
                NewName = footballer.Name,
                NewPosition = footballer.Position,
                NewWage = footballer.Wage,
                NewWeight = footballer.Weight,
                Timestamp = DateTime.Now
            });
        }
    }
}
