using MediatR;
using System;
using TransferMarket.Business.Footballers.Models;

namespace TransferMarket.Business.Footballers.Queries
{
    public class GetFootballerStateAtGivenTimeQuery : IRequest<FootballerState>
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
    }
}
