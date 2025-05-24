using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Application.Common.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        //khai báo một hàm dung chung
        //thêm sửa xoá dữ liệu
        IEnumerable<Hotel> GetAll(Expression<Func<Hotel,bool>>? filter=null, string? includeProperties=null);
        Hotel Get(Expression<Func<Hotel, bool>> filter , string? includeProperties = null);

        void Add(Hotel entity);
        void Update(Hotel entity);
        void Remove(Hotel entity);
        void Save();
    }
}
