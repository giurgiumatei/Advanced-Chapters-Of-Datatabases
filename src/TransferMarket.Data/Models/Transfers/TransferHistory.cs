using System;

namespace TransferMarket.Data.Models.Transfers
{
    public class TransferHistory
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public DateTime Timestamp { get; set; }
        public double NewTotalSum { get; set; }

        public Transfer Transfer { get; set; }
    }
}
