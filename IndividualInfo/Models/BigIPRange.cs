﻿using System;
using System.Collections.Generic;

namespace IndividualInfo.Models
{
    public class BigIpRange
    {
        public short Id { get; set; }

        public string BigRange { get; set; }

        public byte Mask { get; set; }

        public string Description { get; set; }

        public IList<IpRange> IpRanges { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}