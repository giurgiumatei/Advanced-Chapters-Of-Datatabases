using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TransferMarket.Business.Footballers.Commands;
using TransferMarket.Data;
using System.Linq;
using System;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class UpdateFootballerCommandHandler : IRequestHandler<UpdateFootballerCommand, bool>
    {
        private readonly TransferMarketContext _context;

        public UpdateFootballerCommandHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateFootballerCommand request, CancellationToken cancellationToken)
        {
            var footballerToBeUpdated = _context.Footballers.FirstOrDefault(footballer => footballer.Id == request.Id);

            if (footballerToBeUpdated == null)
            {
                return false;
            }

            footballerToBeUpdated.Name = request.Name;
            footballerToBeUpdated.Position = request.Position;
            footballerToBeUpdated.Height = request.Height;
            footballerToBeUpdated.Weight = request.Weight;
            footballerToBeUpdated.Wage = request.Wage;

            UpdateHistoryTable(footballerToBeUpdated);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private void UpdateHistoryTable(Data.Models.Footballers.Footballer footballer)
        {
            _context.FootballerHistories.Add(new Data.Models.Footballers.FootballerHistory
            {
                FootballerId = footballer.Id,
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
