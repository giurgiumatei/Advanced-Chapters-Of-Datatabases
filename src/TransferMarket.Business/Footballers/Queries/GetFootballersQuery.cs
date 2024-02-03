using MediatR;
using System.Collections.Generic;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetFootballersQuery : IRequest<IEnumerable<Footballer>>
    {
    }
}
