using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelNumberRepository HotelNumber { get; }
        IHotelRepository Hotel { get; }
        IAmentityRepository Amentity { get; }
        IBookingRepository Booking { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
