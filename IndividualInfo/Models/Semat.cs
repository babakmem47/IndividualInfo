using System.Collections.Generic;

namespace IndividualInfo.Models
{
    public class Semat
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public IList<Individual> Individuals { get; set; }
    }
}