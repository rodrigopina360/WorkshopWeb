using System.ComponentModel.DataAnnotations;

namespace Workshop.Web.Models.ViewModels
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
