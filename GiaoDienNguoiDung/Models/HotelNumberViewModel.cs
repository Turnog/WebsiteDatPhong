using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using NghiepVu.Entities;

namespace GiaoDienNguoiDung.Models
{
    public class HotelNumberViewModel
    {
        public HotelNumber? HotelNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? HotelList { get; set; }
    }
}
