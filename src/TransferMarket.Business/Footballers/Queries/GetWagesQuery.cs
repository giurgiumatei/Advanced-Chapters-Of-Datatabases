using MediatR;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetWagesQuery : IRequest<WageReport>
    {
        public int Id { get; set; }
    }
}
