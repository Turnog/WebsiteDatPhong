using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using NghiepVu.Entities;

namespace GiaoDienNguoiDung.Models
{
    public class AmentityViewModel
    {
        public Amentity? Amentity { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? HotelList { get; set; }
    }
}
