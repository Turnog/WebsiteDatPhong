using NghiepVu.Entities;

namespace GiaoDienNguoiDung.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Hotel>? HotelList { get; set; } 

        //ngày nhận phòng
        public DateOnly CheckInDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        //ngày trả phòng
        public DateOnly CheckOutDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        //số đêm
        public int Nights { get; set; } = 1; 
    }
}
