using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant.Models
{
    public class Categories
    {
        [Key]
        [Display(Name = "類別ID")]
        public string CategoryID { get; set; }
        [Display(Name = "類別名稱")]
        public string CategoryName { get; set; }
        [Display(Name = "父類別ID")]
        public string FatherCategoryID { get; set; }

        [ForeignKey("FatherCategoryID")]
        public Categories FatherCategory { get; set; }

        public ICollection<Categories> Categoriess { get; set; }
    }
}
