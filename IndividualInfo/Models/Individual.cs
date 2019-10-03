
namespace IndividualInfo.Models
{
    public class Individual
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? Gender { get; set; }

        public string TelDirect { get; set; }

        public string TelDakheli { get; set; }

        public string Mobile { get; set; }

        public string Description { get; set; }

        public Semat Semat { get; set; }

        public byte? SematId { get; set; }

        public bool? Deleted { get; set; }

        public string Email { get; set; }

        public WorkPlace WorkPlace { get; set; }

        public int? WorkPlaceId { get; set; }
    }
}