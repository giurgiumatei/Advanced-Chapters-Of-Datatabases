using System;
using System.Collections.Generic;
using TransferMarket.Data.Models.Footballers;
using TransferMarket.Data.Models.Teams;

namespace TransferMarket.Data.Models.Transfers
{
    public class Transfer
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public int TeamId { get; set; }
        public double TotalSum { get; set; }

        public Footballer Footballer { get; set; }
        public Team Team { get; set; }
        public List<TransferHistory> TransferHistory { get; set; }
    }
}
