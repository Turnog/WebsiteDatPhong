using Application.Common.Interfaces;
using Application.Common.Utility;
using GiaoDienNguoiDung.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NghiepVu.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GiaoDienNguoiDung.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login(string redirectUrl = null)
        {
            redirectUrl??= Url.Content ("~/");
            LoginViewModel loginViewModel = new ()
            {
                RedirectUrl = redirectUrl
            };  
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var ketQua = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);

                if (ketQua.Succeeded)
                {          

                    if (string.IsNullOrEmpty(loginViewModel.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginViewModel.RedirectUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không chính xác.");
                }
            }
            return View(loginViewModel);
        }


        public IActionResult Register(string returnUrl=null)
        {
            returnUrl ??= Url.Content("/");
            if (!_roleManager.RoleExistsAsync(UserRoles.Role_DoangNhiep).GetAwaiter().GetResult()) 
            { 
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Role_DoangNhiep)).Wait();
                _roleManager.CreateAsync(new IdentityRole(UserRoles.Role_KhachHang)).Wait();
            }

            //danh sách tài khoản (admin)
            RegisterViewModel registerViewModel = new ()
            {
                RoleList = _roleManager.Roles.Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList()
            };
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            ApplicationUser applicationUser = new ()
            {
                Name = registerViewModel.Email,
                Email = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber,
                UserName = registerViewModel.Email,
                CreatedDate = DateTime.Now,
                EmailConfirmed = true,
                NormalizedEmail = registerViewModel.Email.ToLower(),
            };

            var ketQua = await _userManager.CreateAsync(applicationUser, registerViewModel.Password);
            if (ketQua.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerViewModel.Role)) 
                { 
                    await _userManager.AddToRoleAsync(applicationUser, registerViewModel.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(applicationUser, UserRoles.Role_DoangNhiep);
                }
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                if(string.IsNullOrEmpty(registerViewModel.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(registerViewModel.RedirectUrl);
                }
            }
            foreach (var error in ketQua.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            registerViewModel.RoleList = _roleManager.Roles.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Name
            });

            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //access denied
        public IActionResult AccessDenied(string returnUrl = null)
        {
            return View();
        }
    }
}
