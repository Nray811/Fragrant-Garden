using System.ComponentModel.DataAnnotations;

namespace petsFragrant_Test.Models
{
    public class ProductSpec
    {

        public string SpecID { get; set; }
        public string ProdcutId { get; set; }

        public Spec Spec { get; set; }
        public Product Product { get; set; }    
    }
}
