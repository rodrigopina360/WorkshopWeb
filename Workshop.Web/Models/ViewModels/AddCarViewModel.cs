using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Workshop.Web.Models.ViewModels
{
    public class AddCarViewModel
    {
        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
