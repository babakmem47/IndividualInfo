using IndividualInfo.Models;
using System.Data.Entity.ModelConfiguration;

namespace IndividualInfo.EntityConfigurations
{
    public class IndividualConfiuration : EntityTypeConfiguration<Individual>
    {
        public IndividualConfiuration()
        {
            Property(p => p.Id)
                .HasColumnOrder(0);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Name");

            //Property(p => p.Gender)
            //    .HasColumnOrder(2);

            Property(p => p.TelDirect)
                .HasMaxLength(50);                      //0098[-]2188267781

            Property(p => p.TelDakheli)
                .HasMaxLength(40);

            Property(p => p.Mobile)                     //00989126384181
                .HasMaxLength(50);

            Property(p => p.Email)
                .HasMaxLength(40);

            Property(p => p.Description)
                .HasMaxLength(250);

            //Many-To-(0..1) with Semat
            HasOptional(p => p.Semat)
                .WithMany(s => s.Individuals)
                .HasForeignKey(p => p.SematId);


        }
    }
}