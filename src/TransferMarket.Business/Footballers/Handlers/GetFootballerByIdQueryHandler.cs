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
    public class GetFootballerByIdQueryHandler : IRequestHandler<GetFootballerByIdQuery, Footballer>
    {
        private readonly TransferMarketContext _context;

        public GetFootballerByIdQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<Footballer> Handle(GetFootballerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Footballers
                .FirstOrDefaultAsync(footballer => footballer.Id == request.Id, cancellationToken: cancellationToken);

            if (result == null) { return null; }

            return new Footballer 
            { 
                Id = result.Id,
                Name = result.Name,
                Height = result.Height,
                Weight = result.Weight,
                Position = result.Position,
                Wage = result.Wage,
            };
        }
    }
}
