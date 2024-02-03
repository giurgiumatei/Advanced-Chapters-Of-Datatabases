using MediatR;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetFootballerStateQuery : IRequest<FootballerState>
    {
        public int Id { get; set; }
    }
}
