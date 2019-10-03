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

            Property(p => p.TelDirect)
                .HasMaxLength(13);                      //021 8826 7781

            Property(p => p.TelDakheli)
                .HasMaxLength(4);

            Property(p => p.Mobile)                     //0912 638 4181
                .HasMaxLength(13);

            Property(p => p.Email)
                .HasMaxLength(40);

            Property(p => p.Description)
                .HasMaxLength(250);

            //Many-To-(0..1) with Semat
            HasOptional(p => p.Semat)
                .WithMany(s => s.Individuals)
                .HasForeignKey(p => p.SematId);

            //Many-To-(0..1) with WorkPlace
            HasOptional(p => p.WorkPlace)
                .WithMany(w => w.Individuals)
                .HasForeignKey(p => p.WorkPlaceId);
        }
    }
}