using MediatR;

namespace TransferMarket.Business.Teams.Commands
{
    public class DeleteTeamCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
