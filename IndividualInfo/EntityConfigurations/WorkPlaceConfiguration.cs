using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class WorkPlaceConfiguration : EntityTypeConfiguration<WorkPlace>
    {
        public WorkPlaceConfiguration()
        {
            Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(60);      // like : نوآوران شبکه فربین

            Property(w => w.Tel)
                .HasMaxLength(40);

            Property(w => w.Address)
                .HasMaxLength(130);

            //(0..1)-To-Many with Individual
            HasMany(w => w.Individuals)
                .WithOptional(p => p.WorkPlace)
                .WillCascadeOnDelete(false);

            //Many-To-1 with WorkPlaceType
            HasRequired(w => w.WorkPlaceType)
                .WithMany(wt => wt.WorkPlaces)
                .HasForeignKey(w => w.WorkPlaceTypeId);

        }
    }
}