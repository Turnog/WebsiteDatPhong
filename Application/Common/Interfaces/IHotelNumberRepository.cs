using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IHotelNumberRepository : IRepository<HotelNumber>
    {
        void Update(HotelNumber entity);
        void Save();
    }
}
