
namespace IndividualInfo.Models
{
    public class IpAddress
    {
        public int Id { get; set; }

        public string Ipv4 { get; set; }

        public int IpRangeId { get; set; }

        public IpRange IpRange { get; set; }

        public string Description { get; set; }

        public Router Router { get; set; }
    }
}