using System.ComponentModel.DataAnnotations;

namespace petsFragrant_Test.Models
{
    public class OrderDetail
    {
    
        public string ProdcutId { get; set; }
        public string OrderID { get; set; }
        public int Amount { get; set; } 
        public decimal QtDiscount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
