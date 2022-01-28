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
    public class ClientsService : EntityBaseRepository<Client>, IClientsService
    {
        public ClientsService(AppDbContext context) : base(context) { }
       
    }
}
