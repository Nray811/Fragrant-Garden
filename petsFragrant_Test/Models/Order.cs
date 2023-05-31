using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant_Test.Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        [Required]
        public string CustomerID { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Shipdate { get; set; }
        public DateTime Arriiveddate { get; set; }
        public string Payment { get; set; }
        public string Delivery { get; set; }
        public ICollection<OrderDetail> Ordertails { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
