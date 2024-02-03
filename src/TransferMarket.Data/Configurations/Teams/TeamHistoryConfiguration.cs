using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Data.Models.Teams;

namespace TransferMarket.Data.Configurations.Teams
{
    public class TeamHistoryConfiguration : IEntityTypeConfiguration<TeamHistory>
    {
        public void Configure(EntityTypeBuilder<TeamHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.NewTotalValue).IsRequired();
            builder.Property(x => x.NewBudget).IsRequired();
        }
    }
}
