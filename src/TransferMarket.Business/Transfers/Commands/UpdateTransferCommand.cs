using MediatR;

namespace TransferMarket.Business.Transfers.Commands
{
    public class UpdateTransferCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public double TotalSum { get; set; }
    }
}
