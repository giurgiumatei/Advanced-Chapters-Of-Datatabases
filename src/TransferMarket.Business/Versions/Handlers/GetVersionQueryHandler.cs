using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransferMarket.Business.Versions.Models;
using TransferMarket.Business.Versions.Queries;
using TransferMarket.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TransferMarket.Business.Versions.Handlers
{
    public class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, VersionCode>
    {
        private readonly TransferMarketContext _context;

        public GetVersionQueryHandler(TransferMarketContext context)
        {
            _context = context;
        }

        public async Task<VersionCode> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            return await _context.ApplicationVersions
                .Where(v => v.Name == request.Name)
                .ToVersionCode()
                .FirstOrDefaultAsync();
        }
    }
}
