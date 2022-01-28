using CarRentals.Data;
using CarRentals.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Models
{
    public class Car:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage ="Model must be between 2 and 20 chars")]
        public string Model { get; set; }
        [Display(Name = "Mark")]
        [Required(ErrorMessage = "Mark is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Mark must be between 2 and 20 chars")]
        public string Mark { get; set; }
        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Photo is required")]
        public string Photo { get; set; }
        [Display(Name = "Description of auto")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 50 chars")]

        public string Description { get; set; }
        [Display(Name = "Price per day")]
        [Required(ErrorMessage = "Price is required")]


        public double Price { get; set; }
        [Display(Name = "Avilable")]
        public bool Avilable { get; set; }

    }

}
