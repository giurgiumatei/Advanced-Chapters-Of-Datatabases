using System;

namespace TransferMarket.Data.Models.Footballers
{
    public class FootballerHistory
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public DateTime Timestamp { get; set; }
        public string NewName { get; set; }
        public double NewHeight { get; set; }
        public double NewWeight { get; set; }
        public string NewPosition { get; set; }
        public double NewWage { get; set; }

        public Footballer Footballer { get; set; }
    }
}
