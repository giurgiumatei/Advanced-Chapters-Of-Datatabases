using MediatR;
using System.Collections.Generic;
using TransferMarket.Business.Teams.Models;

namespace TransferMarket.Business.Teams.Queries
{
    public class GetTeamsQuery : IRequest<IEnumerable<Team>>
    {
    }
}
