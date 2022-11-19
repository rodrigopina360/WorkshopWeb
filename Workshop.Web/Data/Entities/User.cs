using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Workshop.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "User Image")]
        public string ImagePath { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
