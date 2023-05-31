using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant_Test.Models
{
    public class Categories
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string FatherCategoryID { get; set; }

        [ForeignKey("FatherCategoryID")]
        public Categories FatherCategory { get; set; }

        public ICollection<Categories> Categoriess { get; set; }
    }
}
