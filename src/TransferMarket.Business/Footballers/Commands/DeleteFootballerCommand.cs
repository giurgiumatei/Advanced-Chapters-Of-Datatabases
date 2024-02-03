using MediatR;

namespace TransferMarket.Business.Footballers.Commands
{
    public class DeleteFootballerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
