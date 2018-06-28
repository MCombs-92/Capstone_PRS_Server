using PRS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRS_Server.Controllers
{
    public class PurchaseRequestsController : ApiController {

        private PRSDBContext db = new PRSDBContext();


        [HttpGet]
        [ActionName("List")]
        public IEnumerable<PurchaseRequest> List() {
            return db.PurchaseRequests.ToList();
        }

        [HttpGet]
        [ActionName("Get")]
        public PurchaseRequest Get(int? id) {
            if (id == null) {
                return null;
            }
            return db.PurchaseRequests.Find(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public bool Create(PurchaseRequest purchaserequest) {
            if (purchaserequest == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            db.PurchaseRequests.Add(purchaserequest);
            db.SaveChanges();
            return true;

        }

        [HttpPost]
        [ActionName("Change")]
        public bool Change(PurchaseRequest purchaserequest) {
            if (purchaserequest == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var pr = db.PurchaseRequests.Find(purchaserequest.Id);
            pr.Description= purchaserequest.Description;
            pr.Justification= purchaserequest.Justification;
            pr.RejectionReason= purchaserequest.RejectionReason;
            pr.DeliveryMode= purchaserequest.DeliveryMode;
            pr.Status= purchaserequest.Status;
            pr.Total= purchaserequest.Total;
            pr.UserId= purchaserequest.UserId;
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        [ActionName("Remove")]
        public bool Remove(PurchaseRequest purchaserequest) {
            if (purchaserequest == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var pr = db.PurchaseRequests.Find(purchaserequest.Id);
            db.PurchaseRequests.Remove(pr);
            db.SaveChanges();
            return true;

        }

    }
}
