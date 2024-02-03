using System.Collections.Generic;
using TransferMarket.Data.Models.Transfers;

namespace TransferMarket.Data.Models.Footballers
{
    public class Footballer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Position { get; set; }
        public double Wage { get; set; }

        public Transfer Transfer { get; set; }
        public List<FootballerHistory> FootballerHistory { get; set; }
    }
}
