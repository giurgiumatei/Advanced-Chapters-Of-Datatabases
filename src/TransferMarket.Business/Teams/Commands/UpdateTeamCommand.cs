using MediatR;

namespace TransferMarket.Business.Teams.Commands
{
    public class UpdateTeamCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string League { get; set; }
        public double TotalValue { get; set; }
        public double Budget { get; set; }
    }
}
