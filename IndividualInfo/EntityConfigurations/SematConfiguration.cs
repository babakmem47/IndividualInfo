using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class SematConfiguration : EntityTypeConfiguration<Semat>
    {
        public SematConfiguration()
        {
            HasKey(s => s.Id);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);


            //(0..1)-To-Many with Individual
            HasMany(s => s.Individuals)
                .WithOptional(p => p.Semat)
                .WillCascadeOnDelete(false);
        }
    }
}