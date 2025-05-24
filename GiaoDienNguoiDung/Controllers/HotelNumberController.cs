using Application.Common.Utility;
using GiaoDienNguoiDung.Models;
using KetNoiDB.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NghiepVu.Entities;

namespace GiaoDienNguoiDung.Controllers
{
    [Authorize(Roles = UserRoles.Role_DoangNhiep)]
    public class HotelNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HotelNumberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var hotelNumbers = _db.HotelNumbers.Include(h =>h.Hotel).ToList();
            return View(hotelNumbers);
        }

        public IActionResult Create()
        {
            HotelNumberViewModel hotelNumberViewModel = new ()
            {
                HotelList = _db.Hotels.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                })
            };

            return View(hotelNumberViewModel);
        }

        [HttpPost]
        public IActionResult Create(HotelNumberViewModel hotelNumberViewModel)
        {

            bool isNumberUnique = _db.HotelNumbers.Any(h => h.Hotel_Number == hotelNumberViewModel.HotelNumber.Hotel_Number);
            //ModelState.Remove("Hotel");
            if (ModelState.IsValid && !isNumberUnique)
            {
                _db.HotelNumbers.Add(hotelNumberViewModel.HotelNumber);
                _db.SaveChanges();
                return RedirectToAction("Index", "HotelNumber");
            }

            if (isNumberUnique)
            {
                TempData["error"]= "Số phòng đã tồn tại";
            }

            hotelNumberViewModel.HotelList = _db.Hotels.ToList().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            });

            return View(hotelNumberViewModel);
        }

        public IActionResult Update(int hotelNumberId)
        {
            var hotels = _db.Hotels.ToList();
            if (hotels == null || !hotels.Any())
            {
                TempData["error"] = "Không có dữ liệu";
                return NotFound();
            }
            var hotelNumber = _db.HotelNumbers.FirstOrDefault(h => h.Hotel_Number == hotelNumberId);
            if (hotelNumber == null) 
            {
                TempData["error"] = "Không có dữ liệu";
                return NotFound(); 
            }
            HotelNumberViewModel hotelNumberViewModel = new()
            {
                HotelList = hotels.Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }).ToList(),
                HotelNumber = hotelNumber
            };
            return View(hotelNumberViewModel);
        }

        [HttpPost]
        public IActionResult Update(HotelNumberViewModel hotelNumberViewModel)
        {
            if (ModelState.IsValid)
            {
                if (hotelNumberViewModel.HotelNumber != null)
                {
                    try
                    {
                        _db.HotelNumbers.Update(hotelNumberViewModel.HotelNumber);
                        _db.SaveChanges();
                        TempData["success"] = "Cập nhật thành công";
                        return RedirectToAction("Index", "HotelNumber");
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = "Cập nhật thất bại phòng : " + ex.Message;
                    }
                }
                hotelNumberViewModel.HotelList = _db.Hotels.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }).ToList();   
            }
            return View(hotelNumberViewModel);
        }

        public IActionResult Delete(int hotelNumberId)
        {
            HotelNumberViewModel hotelNumberViewModel = new()
            {
                HotelList = _db.Hotels.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }),
                HotelNumber = _db.HotelNumbers.FirstOrDefault(h => h.Hotel_Number == hotelNumberId),
            };
            if (hotelNumberViewModel.HotelNumber == null)
            {
                return NotFound();
            }
            return View(hotelNumberViewModel);
        }
        [HttpPost]
        public IActionResult Delete(HotelNumberViewModel hotelNumberViewModel)
        {
            HotelNumber? itemFormDatabase = _db.HotelNumbers.FirstOrDefault(h => h.Hotel_Number == hotelNumberViewModel.HotelNumber.Hotel_Number);
            if (itemFormDatabase != null)
            {
                _db.HotelNumbers.Remove(itemFormDatabase);
                _db.SaveChanges();
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Index", "HotelNumber");
            }
            TempData["error"] = "Xóa không thành công";
            return View();
        }
    }
}
