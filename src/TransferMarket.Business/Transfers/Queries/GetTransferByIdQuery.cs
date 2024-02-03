using MediatR;
using TransferMarket.Business.Transfers.Models;

namespace TransferMarket.Business.Transfers.Queries
{
    public class GetTransferByIdQuery : IRequest<Transfer>
    {
        public int Id { get; set; }
    }
}
