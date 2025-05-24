using Application.Common.Interfaces;
using KetNoiDB.Data;
using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi.Repository
{
    public class HotelNumberRepository : Repository<HotelNumber>, IHotelNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(HotelNumber entity)
        {
            _db.Update(entity);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    } 
}

