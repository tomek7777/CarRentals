using CarRentals.Data.BaseRepository;
using CarRentals.Data.Enums.Services;
using CarRentals.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Data.Services
{
    public class CarsService : EntityBaseRepository<Car>, ICarsService
    {
        public CarsService(AppDbContext context) : base(context) { }
        
    }
}
