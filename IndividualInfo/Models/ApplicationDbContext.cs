using IndividualInfo.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IndividualInfo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Semat> Semats { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<WorkPlaceType> WorkPlaceTypes { get; set; }
        public DbSet<Router> Routers { get; set; }
        public DbSet<IpAddress> Ips { get; set; }
        public DbSet<IpRange> IpRanges { get; set; }
        public DbSet<BigIpRange> BigIpRanges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IndividualConfiuration());
            modelBuilder.Configurations.Add(new SematConfiguration());
            modelBuilder.Configurations.Add(new WorkPlaceConfiguration());
            modelBuilder.Configurations.Add(new WorkPlaceTypeConfiguration());
            modelBuilder.Configurations.Add(new RouterConfiguration());
            modelBuilder.Configurations.Add(new IpAddressConfiguration());
            modelBuilder.Configurations.Add(new IpRangeConfiguration());
            modelBuilder.Configurations.Add(new BigIpRangeConfiguration());


            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}