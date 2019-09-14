using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class IndividualConfiuration : EntityTypeConfiguration<Individual>
    {
        public IndividualConfiuration()
        {
            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.TelDirect)
                .HasMaxLength(15);                      //0098[-]2188267781

            Property(p => p.TelDakheli)
                .HasMaxLength(4);

            Property(p => p.Mobile)                     //00989126384181
                .HasMaxLength(14);

            //Many-To-(0..1) with Semat
            HasOptional(p => p.Semat)
                .WithMany(s => s.Individuals)
                .HasForeignKey(p => p.SematId);


        }
    }
}