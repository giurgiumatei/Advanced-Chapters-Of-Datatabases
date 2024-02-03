using MediatR;

namespace TransferMarket.Business.Transfers.Commands
{
    public class DeleteTransferCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
