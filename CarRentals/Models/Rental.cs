using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        
    }
}
