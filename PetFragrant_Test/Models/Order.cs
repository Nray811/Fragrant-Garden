using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "訂單ID")]
        public string OrderID { get; set; }
        [Required]
        [Display(Name = "顧客ID")]
        public string CustomerID { get; set; }
        [Display(Name = "訂購日期")]
        public DateTime Orderdate { get; set; }
        [Display(Name = "送貨日期")]
        public DateTime Shipdate { get; set; }
        [Display(Name = "到達日期")]
        public DateTime Arriiveddate { get; set; }
        [Display(Name = "付款方式")]
        public string Payment { get; set; }
        [Display(Name = "運送方式")]
        public string Delivery { get; set; }
        public ICollection<OrderDetail> Ordertails { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
