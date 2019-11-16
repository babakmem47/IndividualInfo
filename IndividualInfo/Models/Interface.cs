namespace IndividualInfo.Models
{
    public class Interface
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short Vlan { get; set; }

        public int IpId { get; set; }

        public IpAddress IpAddress { get; set; }

        public string MacAddress { get; set; }
    }
}