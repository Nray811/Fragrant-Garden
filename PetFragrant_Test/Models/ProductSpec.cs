using System.ComponentModel.DataAnnotations;

namespace petsFragrant.Models
{
    public class ProductSpec
    {
        [MaxLength(10)]
        [Display(Name = "規格ID")]
        public string SpecID { get; set; }
        [Display(Name = "產品ID")]
        public string ProdcutId { get; set; }

        public Spec Spec { get; set; }
        public Product Product { get; set; }    
    }
}
