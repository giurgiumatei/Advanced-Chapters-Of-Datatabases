using MediatR;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetMaximumWagePeriodQuery : IRequest<MaximumWagePeriod>
    {
        public int Id { get; set; }
    }
}
