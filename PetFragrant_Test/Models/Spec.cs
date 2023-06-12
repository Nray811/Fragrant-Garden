using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace petsFragrant.Models
{
    public class Spec
    {
        [StringLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "規格ID")]
        public string SpecID { get; set; }
        [Display(Name = "規格名稱")]
        public string SpecName { get; set; }
        public ICollection<ProductSpec> ProductSpec { get; set; }
    }
}
