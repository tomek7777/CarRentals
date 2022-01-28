using CarRentals.Data;
using CarRentals.Data.Enums.Services;
using CarRentals.Data.Static;
using CarRentals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class RentalsController : Controller
    {
        private readonly IRentalsService _service;
        public RentalsController(IRentalsService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            await _service.AddAsync(rental);
            return RedirectToAction(nameof(Index));
        }

        //Cars ID
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var rentalDetails = await _service.GetByIdAsync(id);

            if (rentalDetails == null) return View("NotFound");
            return View(rentalDetails);
        }


        //Get: Rentals/EDIT

        public async Task<IActionResult> Edit(int id)
        {
            var rentalDetails = await _service.GetByIdAsync(id);
            if (rentalDetails == null) return View("NotFound");
            return View(rentalDetails);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,  Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }           
            await _service.UpdateAsync(id, rental);
            return RedirectToAction(nameof(Index));
            
        }

        //Get: Rental/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var rentalDetails = await _service.GetByIdAsync(id);
            if (rentalDetails == null) return View("NotFound");
            return View(rentalDetails);


        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalDetails = await _service.GetByIdAsync(id);
            if (rentalDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}

