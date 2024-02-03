using MediatR;

namespace TransferMarket.Business.Footballers.Commands
{
    public class AddFootballerCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Position { get; set; }
        public double Wage { get; set; }
    }
}
