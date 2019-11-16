using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class RouterConfiguration : EntityTypeConfiguration<Router>
    {
        public RouterConfiguration()
        {
            Property(r => r.Name)
                .IsOptional()
                .HasMaxLength(50);

            Property(r => r.Model)
                .IsRequired()
                .HasMaxLength(30);

            Property(r => r.HostName)
                .HasMaxLength(50);

            Property(r => r.IosVersion)
                .HasMaxLength(50);

            Property(r => r.Clock)
                .HasMaxLength(50);

            //(0..1)-To-(0..1) with IpAddress(Mgmt ip)  
            //  Router ------- IP
            // Router is a parent because we cannot have an ip without having a router in the first place
            // in EF: parent is Principal and child is Dependent
            HasOptional(r => r.IpAddress)
                .WithOptionalDependent(ip => ip.Router);


            //Many-To-1 with WorkPlace
            HasRequired(r => r.WorkPlace)
                .WithMany(wp => wp.Routers)
                .WillCascadeOnDelete(false);

        }
    }
}