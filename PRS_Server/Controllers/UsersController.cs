﻿using PRS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRS_Server.Controllers
{
    public class UsersController : ApiController {

        private PRSDBContext db = new PRSDBContext();


        [HttpGet]
        [ActionName("List")]
        public IEnumerable<User> List() {
            return db.Users.ToList();
        }

        [HttpGet]
        [ActionName("Get")]
        public User Get(int? id) {
            if (id == null) {
                return null;
            }
            return db.Users.Find(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public bool Create(User user) {
            if (user == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            db.Users.Add(user);
            db.SaveChanges();
            return true;

        }

        [HttpPost]
        [ActionName("Change")]
        public bool Change(User user) {
            if (user == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var us = db.Users.Find(user.Id);
            us.Username = user.Username;
            us.Password = user.Password;
            us.FirstName = user.FirstName;
            us.LastName = user.LastName;
            us.Phone = user.Phone;
            us.Email = user.Email;
            us.IsReviewer = user.IsReviewer;
            us.IsAdmin = user.IsAdmin;
            us.Active = user.Active;
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        [ActionName("Remove")]
        public bool Remove(User user) {
            if (user == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var us = db.Users.Find(user.Id);
            db.Users.Remove(us);
            db.SaveChanges();
            return true;

        }

    }
}
