using PRS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRS_Server.Controllers
{
    public class PurchaseRequestLineItemsController : ApiController {

        private PRSDBContext db = new PRSDBContext();


        [HttpGet]
        [ActionName("List")]
        public IEnumerable<PurchaseRequestLineItem> List() {
            return db.PurchaseRequestLineItems.ToList();
        }

        [HttpGet]
        [ActionName("Get")]
        public PurchaseRequestLineItem Get(int? id) {
            if (id == null) {
                return null;
            }
            return db.PurchaseRequestLineItems.Find(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public bool Create(PurchaseRequestLineItem purchaseRequestLineItems) {
            if (purchaseRequestLineItems == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            db.PurchaseRequestLineItems.Add(purchaseRequestLineItems);
            db.SaveChanges();
            return true;

        }

        [HttpPost]
        [ActionName("Change")]
        public bool Change(PurchaseRequestLineItem purchaseRequestLineItems) {
            if (purchaseRequestLineItems == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var prli = db.PurchaseRequestLineItems.Find(purchaseRequestLineItems.Id);
            prli.PurchaseRequestId= purchaseRequestLineItems.PurchaseRequestId;
            prli.ProductId= purchaseRequestLineItems.ProductId;
            prli.Quantity= purchaseRequestLineItems.Quantity;
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        [ActionName("Remove")]
        public bool Remove(PurchaseRequestLineItem purchaseRequestLineItems) {
            if (purchaseRequestLineItems == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var prli = db.PurchaseRequestLineItems.Find(purchaseRequestLineItems.Id);
            db.PurchaseRequestLineItems.Remove(prli);
            db.SaveChanges();
            return true;

        }

    }
}
