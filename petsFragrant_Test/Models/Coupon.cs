using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant_Test.Models
{
    public class Coupon
    {
        [Key]
        public string CouponID { get; set; }
        public string OrderID { get; set; }
        public DateTime Period { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        [ForeignKey("OrderID")]
        public Order Orders { get; set; }

    }
}
