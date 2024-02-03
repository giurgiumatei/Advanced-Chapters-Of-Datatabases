using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Data.Models.Transfers;

namespace TransferMarket.Data.Configurations.Transfers
{
    public class TransferHistoryConfiguration : IEntityTypeConfiguration<TransferHistory>
    {
        public void Configure(EntityTypeBuilder<TransferHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.NewTotalSum).IsRequired();
        }
    }
}
