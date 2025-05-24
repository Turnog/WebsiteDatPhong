using Application.Common.Interfaces;
using Application.Common.Utility;
using KetNoiDB.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NghiepVu.Entities;
using System.Diagnostics.Metrics;

namespace GiaoDienNguoiDung.Controllers
{
    [Authorize(Roles = UserRoles.Role_DoangNhiep)]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelController(IHotelRepository hotelRepository, IWebHostEnvironment webHostEnvironment)
        {
            _hotelRepository = hotelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var hotels = _hotelRepository.GetAll(); 
            return View(hotels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (hotel.Name == hotel.Description)
            {
                ModelState.AddModelError("", "Tên khách sạn không được trùng với vị trí");
            }
            if (ModelState.IsValid)
            {
                if(hotel.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"img\hotel");

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }
                    hotel.ImageUrl = @"\img\hotel\" + fileName;
                }
                    _hotelRepository.Add(hotel);
                _hotelRepository.Save();
                return RedirectToAction("Index", "Hotel");
            }
            return View();
        }

        public IActionResult Update(int hotelId)
        {
            Hotel? hotel = _hotelRepository.Get(h => h.Id == hotelId);

            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }
        [HttpPost]
        public IActionResult Update(Hotel hotel)
        {
            if (ModelState.IsValid && hotel.Id > 0)
            {
                if (hotel.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hotel.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"img\hotel");

                    if(!string.IsNullOrEmpty(hotel.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, hotel.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        hotel.Image.CopyTo(fileStream);
                    }
                    hotel.ImageUrl = @"\img\hotel\" + fileName;
                }
                _hotelRepository.Update(hotel);
                _hotelRepository.Save();
                return RedirectToAction("Index", "Hotel");
            }
            return View();
        }

        public IActionResult Delete(int hotelId)
        {
            Hotel? hotel = _hotelRepository.Get(h => h.Id == hotelId);

            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }
        [HttpPost]
        public IActionResult Delete(Hotel hotel)
        {
            Hotel? hotelFormDatabase = _hotelRepository.Get(h => h.Id == hotel.Id);
            if (hotelFormDatabase != null)
            {
                if (!string.IsNullOrEmpty(hotelFormDatabase.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, hotelFormDatabase.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _hotelRepository.Remove(hotelFormDatabase);
                _hotelRepository.Save();
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Index", "Hotel");
            }
            TempData["error"] = "Xóa không thành công";
            return View();
        }
    }
}
