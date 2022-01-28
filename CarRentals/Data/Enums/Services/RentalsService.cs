using CarRentals.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.Data.Enums.Services;
using CarRentals.Data.BaseRepository;

namespace CarRentals.Data.Services
{
    public class RentalsService : IRentalsService
    {
        private readonly AppDbContext _context;
        public RentalsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Rental rental)
        {
            var carDetails = await _context.Cars.FirstOrDefaultAsync(c => c.Id == rental.CarId);
            carDetails.Avilable = false;
            _context.Rentals.Add(rental);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Rentals.FirstOrDefaultAsync(n => n.Id == id);
            _context.Rentals.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            var result = await _context.Rentals.ToListAsync();
            return result;
        }

        public async Task<Rental> GetByIdAsync(int id)
        {
            var result = await _context.Rentals.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Rental> UpdateAsync(int id, Rental newRental)
        {
            _context.Update(newRental);
            await _context.SaveChangesAsync();
            return newRental;
        }
    }
}

