using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class WorkPlaceTypeConfiguration : EntityTypeConfiguration<WorkPlaceType>
    {
        public WorkPlaceTypeConfiguration()
        {
            HasKey(wt => wt.Id);

            Property(wt => wt.Name)
                .IsRequired()
                .HasMaxLength(20);      // like:  شرکت / اداره / سرپرستی / شعبه / غیره

            // 1-To-Many with WorkPlace
            HasMany(wt => wt.WorkPlaces)
                .WithRequired(w => w.WorkPlaceType)
                .WillCascadeOnDelete(false);
        }
    }
}