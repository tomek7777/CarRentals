using CarRentals.Data;
using CarRentals.Data.Enums.Services;
using CarRentals.Data.Static;
using CarRentals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ClientsController : Controller
    {
        private readonly IClientsService _service;
        public ClientsController(IClientsService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Adress,PhoneNo")] Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            await _service.AddAsync(client);
            return RedirectToAction(nameof(Index));
        }

        //Client ID
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var clientDetails = await _service.GetByIdAsync(id);

            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);
        }


        //Get: Clients/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var clientDetails = await _service.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Adress,PhoneNo")] Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            await _service.UpdateAsync(id, client);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cars/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var clientDetails = await _service.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);


        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientDetails = await _service.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
