using TransferMarket.Data.Configurations.ApplicationVersions;
using TransferMarket.Data.Models.ApplicationVersions;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Data.Models.Footballers;
using TransferMarket.Data.Models.Teams;
using TransferMarket.Data.Models.Transfers;
using TransferMarket.Data.Configurations.Footballers;
using TransferMarket.Data.Configurations.Teams;
using TransferMarket.Data.Configurations.Transfers;

namespace TransferMarket.Data
{
    public class TransferMarketContext : DbContext
    {
        public TransferMarketContext() { }

        public TransferMarketContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        public virtual DbSet<Footballer> Footballers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }

        public virtual DbSet<FootballerHistory> FootballerHistories { get; set; }
        public virtual DbSet<TeamHistory> TeamHistories { get; set; }
        public virtual DbSet<TransferHistory> TransferHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
            builder.ApplyConfiguration(new FootballerConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new TransferConfiguration());
            builder.ApplyConfiguration(new FootballerHistoryConfiguration());
            builder.ApplyConfiguration(new TeamHistoryConfiguration());
            builder.ApplyConfiguration(new TransferHistoryConfiguration());
        }
    }
}
