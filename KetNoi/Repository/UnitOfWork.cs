using Application.Common.Interfaces;
using KetNoiDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IAmentityRepository Amentity { get; private set; }
        public IHotelNumberRepository HotelNumber { get; private set; }
        public IHotelRepository Hotel { get; private set; }
        public IBookingRepository Booking { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Amentity = new AmentityRepository(_db);
            Hotel = new HotelRepository(_db);
            HotelNumber = new HotelNumberRepository(_db);
            Booking = new BookingRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }   
    }
}
