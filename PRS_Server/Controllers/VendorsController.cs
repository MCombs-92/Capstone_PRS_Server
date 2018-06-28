using PRS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRS_Server.Controllers
{
    public class VendorsController : ApiController  {

        private PRSDBContext db = new PRSDBContext();


        [HttpGet]
        [ActionName("List")]
        public IEnumerable<Vendor> List() {
            return db.Vendors.ToList();
        }

        [HttpGet]
        [ActionName("Get")]
        public Vendor Get(int? id) {
            if (id == null) {
                return null;
            }
            return db.Vendors.Find(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public bool Create(Vendor vendor) {
            if (vendor == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            db.Vendors.Add(vendor);
            db.SaveChanges();
            return true;

        }

        [HttpPost]
        [ActionName("Change")]
        public bool Change(Vendor vendor) {
            if (vendor == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var vend = db.Vendors.Find(vendor.Id);
            vend.Code = vendor.Code;
            vend.Name= vendor.Name;
            vend.Address= vendor.Address;
            vend.City= vendor.City;
            vend.State= vendor.State;
            vend.Zip= vendor.Zip;
            vend.Phone = vendor.Phone;
            vend.Email = vendor.Email;
            vend.IsPreApproved= vendor.IsPreApproved;
            vend.Active = vendor.Active;
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        [ActionName("Remove")]
        public bool Remove(Vendor vendor) {
            if (vendor == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var vend = db.Vendors.Find(vendor.Id);
            db.Vendors.Remove(vend);
            db.SaveChanges();
            return true;

        }

    }
}
