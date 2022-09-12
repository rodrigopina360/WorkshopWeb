using Microsoft.AspNetCore.Identity;
using System;

namespace Workshop.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime RegisterDate { get; set; }
        public UserType UserType { get; set; }
    }
}
