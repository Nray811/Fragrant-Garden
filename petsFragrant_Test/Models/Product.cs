using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant_Test.Models
{
    public class Product
    {
        [Key]
        public string ProdcutId { get; set; }
        public string CategoriesID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductSpec> ProductSpecs { get; set; }

        [ForeignKey("CategoriesID")]
        public Categories Categories { get; set; }
    }
}
