using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransferMarket.Data.Models.Footballers;

namespace TransferMarket.Data.Configurations.Footballers
{
    public class FootballerConfiguration : IEntityTypeConfiguration<Footballer>
    {
        public void Configure(EntityTypeBuilder<Footballer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Wage).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.Position).IsRequired();

            builder.HasMany(x => x.FootballerHistory)
                .WithOne(x => x.Footballer)
                .HasForeignKey(x => x.FootballerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
