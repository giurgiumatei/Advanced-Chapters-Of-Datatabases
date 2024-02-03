using MediatR;
using TransferMarket.Business.Teams.Models;

namespace TransferMarket.Business.Teams.Queries
{
    public class GetTeamByIdQuery : IRequest<Team>
    {
        public int Id { get; set; }
    }
}
