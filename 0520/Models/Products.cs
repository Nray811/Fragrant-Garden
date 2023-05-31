using System.ComponentModel.DataAnnotations;

namespace _0520.Models
{
    public class Products
    {
        [Display(Name = "產品ID")]
        public int Id { get; set; }
        
        [Display(Name = "產品名稱")]
        public string Name { get; set; }

        [Display(Name = "產品描述")]
        public string Description { get; set; }

        [Display(Name = "產品價格")]
        public decimal Price { get; set; }

        [Display(Name = "產品庫存")]
        public int Inventory { get; set;}
        
        [Display(Name = "折扣趴數")]
        public decimal Discountrate { get { return Price * (decimal)0.9; } }
    }
}
