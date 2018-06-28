using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRS_Server.Models {

    public class User {

        public User() {

        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(80)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
        public bool Active { get; set; }

    }
}