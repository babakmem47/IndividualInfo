
namespace IndividualInfo.Models
{
    public class Individual
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Gender { get; set; }

        public string TelDirect { get; set; }

        public string TelDakheli { get; set; }

        public string Mobile { get; set; }

        public string Description { get; set; }

        public Semat Semat { get; set; }

        public byte? SematId { get; set; }
    }
}