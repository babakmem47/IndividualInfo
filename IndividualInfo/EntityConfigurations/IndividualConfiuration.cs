using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class IndividualConfiuration : EntityTypeConfiguration<Individual>
    {
        public IndividualConfiuration()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.TelDirect)
                .HasMaxLength(15);                      //0098[-]2188267781

            Property(p => p.TelDakheli)
                .HasMaxLength(4);

            Property(p => p.Mobile)                     //00989126384181
                .HasMaxLength(14);

            Property(p => p.Description)
                .HasMaxLength(250);

            //Many-To-(0..1) with Semat
            HasOptional(p => p.Semat)
                .WithMany(s => s.Individuals)
                .HasForeignKey(p => p.SematId);


        }
    }
}