using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.Models
{
    public class IpAddressConfiguration : EntityTypeConfiguration<IpAddress>
    {
        public IpAddressConfiguration()
        {
            Property(ip => ip.Ipv4)
                .IsRequired()
                .HasMaxLength(15);

            Property(ip => ip.Description)
                .HasMaxLength(255);

            // Many-To-1 with IpRange
            HasRequired(ip => ip.IpRange)
                .WithMany(ipr => ipr.Ips)
                .WillCascadeOnDelete(true);  // Delete sub ip if range deleted!?

            // (0..1)-To-(0..1) with Router: Router is parent(Principal) and IpAddress is child(Dependent)
            HasOptional(ip => ip.Router)
                .WithOptionalPrincipal(r => r.IpAddress);
        }
    }
}