using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransferMarket.Data.Models.Transfers;

namespace TransferMarket.Data.Configurations.Transfers
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalSum).IsRequired();

            builder.HasOne(x => x.Footballer)
                   .WithOne(x => x.Transfer)
                   .HasForeignKey<Transfer>(x => x.FootballerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Team)
                   .WithOne(x => x.Transfer)
                   .HasForeignKey<Transfer>(x => x.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TransferHistory)
                    .WithOne(x => x.Transfer)
                    .HasForeignKey(x => x.TransferId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
