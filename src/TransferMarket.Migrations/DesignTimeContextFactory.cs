using TransferMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace TransferMarket.Migrations
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<TransferMarketContext>
    {
        private const string LocalSql = "server=localhost\\SQLEXPRESS;database=TransferMarket-Local;Trusted_Connection=True;";

        private static readonly string MigrationAssemblyName = typeof(DesignTimeContextFactory).Assembly.GetName().Name;

        public TransferMarketContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TransferMarketContext>()
                .UseSqlServer(args.FirstOrDefault() ?? LocalSql,
                op => op.MigrationsAssembly(MigrationAssemblyName));
            return new TransferMarketContext(builder.Options);
        }
    }
}
