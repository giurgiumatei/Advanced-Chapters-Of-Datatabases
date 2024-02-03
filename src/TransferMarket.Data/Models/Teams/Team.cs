using System.Collections.Generic;
using TransferMarket.Data.Models.Transfers;

namespace TransferMarket.Data.Models.Teams
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string League { get; set; }
        public double TotalValue { get; set; }
        public double Budget { get; set; }

        public Transfer Transfer { get; set; }
        public List<TeamHistory> TeamHistory { get; set; }
    }
}
