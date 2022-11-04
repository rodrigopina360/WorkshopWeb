using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Models.ViewModels
{
    public class ChangeUserViewModel : User
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
