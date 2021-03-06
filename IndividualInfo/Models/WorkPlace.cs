﻿using System;
using System.Collections.Generic;

namespace IndividualInfo.Models
{
    public class WorkPlace
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WorkPlaceType WorkPlaceType { get; set; }

        public byte WorkPlaceTypeId { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string FieldOfActivity { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public IList<Individual> Individuals { get; set; }

        public IList<Router> Routers { get; set; }
    }
}