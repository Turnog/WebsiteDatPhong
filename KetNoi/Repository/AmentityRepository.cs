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
    public class AmentityRepository : Repository<Amentity>, IAmentityRepository
    {
        private readonly ApplicationDbContext _db;
        public AmentityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Amentity entity)
        {
            _db.Amentities.Update(entity);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
