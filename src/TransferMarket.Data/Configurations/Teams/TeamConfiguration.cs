using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransferMarket.Data.Models.Teams;

namespace TransferMarket.Data.Configurations.Teams
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.League).HasMaxLength(100);
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.League).IsRequired();
            builder.Property(x => x.TotalValue).IsRequired();
            builder.Property(x => x.Budget).IsRequired();

            builder.HasMany(x => x.TeamHistory)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
