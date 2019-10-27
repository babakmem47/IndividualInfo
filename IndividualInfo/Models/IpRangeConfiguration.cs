using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.Models
{
    public class IpRangeConfiguration : EntityTypeConfiguration<IpRange>
    {
        public IpRangeConfiguration()
        {
            Property(ipr => ipr.Range)
                .IsRequired()
                .HasMaxLength(15);

            Property(ipr => ipr.Description)
                .HasMaxLength(255);

            // 1-To-Many with IpAddress
            HasMany(ipr => ipr.Ips)
                .WithRequired(ip => ip.IpRange);

            // Many-To-(0..1) with BigIpRange
            HasOptional(ipr => ipr.BigIpRange)
                .WithMany(bipr => bipr.IpRanges)
                .WillCascadeOnDelete(true);     // deleting subrange when bigrange deleted
        }
    }
}