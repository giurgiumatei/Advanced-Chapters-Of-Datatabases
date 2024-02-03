using System;

namespace TransferMarket.Data.Models.Teams
{
    public class TeamHistory
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public DateTime Timestamp { get; set; }
        public double NewBudget { get; set; }
        public string NewName { get; set; }
        public string NewCity { get; set; }
        public string NewLeague { get; set; }
        public double NewTotalValue { get; set; }
        public Team Team { get; set; }
    }
}
