using System;

namespace IndividualInfo.Dtos
{
    public class RouterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string IpAddress { get; set; }

        public string WorkPlace { get; set; }

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