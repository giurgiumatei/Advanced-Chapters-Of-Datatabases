using Microsoft.EntityFrameworkCore;

namespace TransferMarket.Migrations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new DesignTimeContextFactory().CreateDbContext(args);
            context.Database.Migrate();
        }
    }
}
