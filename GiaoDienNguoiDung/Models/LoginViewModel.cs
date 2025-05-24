using System.ComponentModel.DataAnnotations;

namespace GiaoDienNguoiDung.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email không được để trống!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        /// chuyển hướng về url cũ
        public string? RedirectUrl { get; set; }
    }
}
