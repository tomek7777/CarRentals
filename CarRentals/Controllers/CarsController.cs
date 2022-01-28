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
    public class CarsController : Controller
    {
        private readonly ICarsService _service;
        public CarsController(ICarsService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Model,Mark,Photo,Description,Price,Avialable")]Car car)
        {
            if (!ModelState.IsValid) 
            {
                return View(car);
            }
            await _service.AddAsync(car);
            return RedirectToAction(nameof(Index));
        }

        //Cars ID
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var carDetails =await _service.GetByIdAsync(id);

            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }


        //Get: Cars/EDIT
        
        public async Task<IActionResult> Edit(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);

           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Mark,Photo,Description,Price,Avialable")] Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            await _service.UpdateAsync(id, car);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cars/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);


        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _service.GetByIdAsync(id);
            if (carDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);            
            return RedirectToAction(nameof(Index));
        }
    }

}
