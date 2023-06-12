using System.ComponentModel.DataAnnotations;

namespace petsFragrant.Models
{
    public class OrderDetail
    {
        [Display(Name = "產品ID")]
        public string ProdcutId { get; set; }
        [Display(Name = "訂單ID")]
        public string OrderID { get; set; }
        [Display(Name = "數量")]
        public int Amount { get; set; }
        [Display(Name = "折扣")]
        public decimal QtDiscount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
