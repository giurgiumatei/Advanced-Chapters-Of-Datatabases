using MediatR;
using System.Collections.Generic;
using TransferMarket.Business.Transfers.Models;

namespace TransferMarket.Business.Transfers.Queries
{
    public class GetTransfersQuery : IRequest<IEnumerable<Transfer>>
    {
    }
}
