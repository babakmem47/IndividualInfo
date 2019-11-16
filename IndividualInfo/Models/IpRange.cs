using System;
using System.Collections.Generic;

namespace IndividualInfo.Models
{
    public class IpRange
    {
        public int Id { get; set; }

        public string Range { get; set; }

        public byte Mask { get; set; }

        public string Description { get; set; }

        public short? BigIpRangeId { get; set; }

        public BigIpRange BigIpRange { get; set; }

        public IList<IpAddress> Ips { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}