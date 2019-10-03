using System.Collections.Generic;

namespace IndividualInfo.Models
{
    public class WorkPlaceType
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public IList<WorkPlace> WorkPlaces { get; set; }
    }
}