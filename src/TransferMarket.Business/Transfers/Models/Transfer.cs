namespace TransferMarket.Business.Transfers.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public int TeamId { get; set; }
        public double TotalSum { get; set; }
    } 
}
