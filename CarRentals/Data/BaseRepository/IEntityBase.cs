using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Data.BaseRepository
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}
