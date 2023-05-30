using System.Collections;
using System.Collections.Generic;

namespace petsFragrant_Test.Models
{
    public class Spec
    {
        public string SpecID { get; set; }

        public string SpecName { get; set; }
        public ICollection<ProductSpec> ProductSpec { get; set; }
    }
}
