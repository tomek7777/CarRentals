using System;
using CarRentals.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Data.BaseRepository;

namespace CarRentals.Models
{
    public class Client:IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "First Name is required")]
        public string  FirstName{ get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress is required")]
        public string Adress { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNo { get; set; }
        
    }
}
