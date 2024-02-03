using TransferMarket.Business.Versions.Models;
using MediatR;

namespace TransferMarket.Business.Versions.Queries
{
    public class GetVersionQuery : IRequest<VersionCode>
    {
        public string Name { get; set; }
    }
}
