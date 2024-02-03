using MediatR;

namespace TransferMarket.Business.Transfers.Commands
{
    public class AddTransferCommand : IRequest<bool>
    {
        public int FootballerId { get; set; }
        public int TeamId { get; set; }
        public double TotalSum { get; set; }
    }
}
