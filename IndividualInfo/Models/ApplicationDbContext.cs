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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IndividualConfiuration());
            modelBuilder.Configurations.Add(new SematConfiguration());
            modelBuilder.Configurations.Add(new WorkPlaceConfiguration());
            modelBuilder.Configurations.Add(new WorkPlaceTypeConfiguration());

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