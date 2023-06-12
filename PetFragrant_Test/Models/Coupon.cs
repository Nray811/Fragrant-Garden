using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petsFragrant.Models
{
    public class Coupon
    {
        [Key]
        [Display(Name = "優惠券ID")]
        public string CouponID { get; set; }
        [Display(Name = "訂單ID")]
        public string OrderID { get; set; }
        [Display(Name = "優惠券到期日")]
        public DateTime Period { get; set; }
        [Display(Name = "打折趴數")]
        public decimal Rate { get; set; }
        [Display(Name = "優惠券描述")]
        public string Description { get; set; }
        [Display(Name = "優惠券名稱")]
        public string Name { get; set; }

        [ForeignKey("OrderID")]
        public Order Orders { get; set; }

    }
}
