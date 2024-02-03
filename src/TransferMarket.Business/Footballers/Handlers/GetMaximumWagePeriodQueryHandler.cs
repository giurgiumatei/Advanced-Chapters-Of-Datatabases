using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Footballers.Models;
using TransferMarket.Business.Footballers.Queries;
using TransferMarket.Data;

namespace TransferMarket.Business.Footballers.Handlers
{
    public class GetMaximumWagePeriodQueryHandler : IRequestHandler<GetMaximumWagePeriodQuery, MaximumWagePeriod>
    {
        private readonly TransferMarketContext _context;

        public GetMaximumWagePeriodQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<MaximumWagePeriod> Handle(GetMaximumWagePeriodQuery request, CancellationToken cancellationToken)
        {
            var maximumWage = (await _context.Footballers
                .Where(f => f.Id == request.Id)
                .OrderByDescending(f => f.Wage)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken))
                ?.Wage;

            if (maximumWage == null)
            {
                return null;
            }


            var startDateForMaximumWage = (await _context.FootballerHistories
                .Where(f => f.FootballerId == request.Id)
                .OrderBy(fh => fh.Timestamp)
                .FirstOrDefaultAsync(fh => fh.NewWage == maximumWage, cancellationToken: cancellationToken))
                .Timestamp;

            var endDateForMaximumWage = (await _context.FootballerHistories
                .Where(f => f.FootballerId == request.Id)
                .OrderByDescending(fh => fh.Timestamp)
                .FirstOrDefaultAsync(fh => fh.NewWage == maximumWage, cancellationToken: cancellationToken))
                .Timestamp;

            return new MaximumWagePeriod
            {
                StartDate = startDateForMaximumWage.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = endDateForMaximumWage.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
