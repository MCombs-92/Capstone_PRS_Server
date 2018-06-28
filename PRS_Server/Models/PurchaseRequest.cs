using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_Server.Models {


    public class PurchaseRequest {

        public PurchaseRequest() {

        }

        public int Id { get; set; }

        [StringLength(80)]
        [Required]
        public string Description { get; set; }

        [StringLength(80)]
        public string Justification { get; set; }

        [StringLength(80)]
        public string RejectionReason { get; set; }

        [StringLength(20)]
        [Required]
        public string DeliveryMode { get; set; }

        [StringLength(15)]
        [Required]
        public string Status { get; set; } = "NEW";

        public double Total { get; set; } = 0;
        public bool Active { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual List<PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; }
        public virtual User User { get; set; }


    }
}