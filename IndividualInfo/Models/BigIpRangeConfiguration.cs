using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.Models
{
    public class BigIpRangeConfiguration : EntityTypeConfiguration<BigIpRange>
    {
        public BigIpRangeConfiguration()
        {
            Property(bipr => bipr.BigRange)
                .IsRequired()
                .HasMaxLength(15);

            Property(bipr => bipr.Description)
                .HasMaxLength(255);

            // (0..1)-To-Many with IpRange
            HasMany(bipr => bipr.IpRanges)
                .WithOptional(ipr => ipr.BigIpRange);
        }
    }
}