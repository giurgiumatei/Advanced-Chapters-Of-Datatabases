namespace TransferMarket.Business.Teams.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string League { get; set; }
        public double TotalValue { get; set; }
        public double Budget { get; set; }
    }
}
