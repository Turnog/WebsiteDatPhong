using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GiaoDienNguoiDung.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email không được để trống!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp!")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }


        /// chuyển hướng về url cũ
        public string? RedirectUrl { get; set; }

        public string? Role { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
