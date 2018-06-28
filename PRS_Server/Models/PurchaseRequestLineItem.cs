using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_Server.Models {


    public class PurchaseRequestLineItem {

        public PurchaseRequestLineItem() {

        }

        public int Id { get; set; }

        [Required]
        public int PurchaseRequestId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public virtual PurchaseRequest PurchaseRequest { get; set; }
        public virtual Product Product { get; set; }

    }
}