using MediatR;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetFootballerByIdQuery : IRequest<Footballer>
    {
        public int Id { get; set; }
    }
}
