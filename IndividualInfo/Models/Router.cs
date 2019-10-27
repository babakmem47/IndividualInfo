using System;

namespace IndividualInfo.Models
{
    public class Router
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        //Mgmt IpAddress
        //public int? IpAddressId { get; set; }    // Migration not setting it as FK, so it is useless(dont know why?)
        // Migration create IpAddress_Id instead and I cannot change it to IpAddressId!! (in migration)
        public IpAddress IpAddress { get; set; }

        public int WorkPlaceId { get; set; }

        public WorkPlace WorkPlace { get; set; }

        public string HostName { get; set; }

        public DateTime InfoDate { get; set; }

        public bool? Ssh { get; set; }

        public bool? Ise { get; set; }

        public string IosVersion { get; set; }

        public short? TunnelNumber { get; set; }

        public byte? DefaultRouteNumber { get; set; }

        public short? IpRouteNumber { get; set; }

        public byte? DownInterfacesNumber { get; set; }

        public DateTime? Uptime { get; set; }

        public byte? DualPower { get; set; }
    }
}