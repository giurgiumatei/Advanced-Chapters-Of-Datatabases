using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransferMarket.Data.Models.Footballers;

namespace TransferMarket.Data.Configurations.Footballers
{
    public class FootballerHistoryConfiguration : IEntityTypeConfiguration<FootballerHistory>
    {
        public void Configure(EntityTypeBuilder<FootballerHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.NewWage).IsRequired();
        }
    }
}
