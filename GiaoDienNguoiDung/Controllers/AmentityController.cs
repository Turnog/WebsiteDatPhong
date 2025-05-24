using Application.Common.Interfaces;
using Application.Common.Utility;
using GiaoDienNguoiDung.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NghiepVu.Entities;

namespace GiaoDienNguoiDung.Controllers
{
    [Authorize(Roles = UserRoles.Role_DoangNhiep)]
    public class AmentityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmentityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var amenities = _unitOfWork.Amentity.GetAll(includeProperties: "Hotel");
            return View(amenities);
        }
        public IActionResult Create()
        {
            AmentityViewModel amentityViewModel = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                })
            };
            return View(amentityViewModel);
        }

        [HttpPost]
        public IActionResult Create(AmentityViewModel amentityViewModel)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Amentity.Add(amentityViewModel.Amentity);
                _unitOfWork.Save();
                TempData["success"] = "Thêm tiện nghi thành công";
                return RedirectToAction("Index", "Amentity");
            }
             
            amentityViewModel.HotelList = _unitOfWork.Hotel.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            });
            return View(amentityViewModel);
        }

        public IActionResult Update(int amentityId)
        {
            var hotels = _unitOfWork.Hotel.GetAll();
            if (hotels == null || !hotels.Any())
            {
                TempData["error"] = "Không tìm thấy dữ liệu";
                return NotFound();
            }
            var amentity = _unitOfWork.Amentity.Get(h => h.Id == amentityId);

            AmentityViewModel amentityViewModel = new()
            {
                HotelList = hotels.Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }).ToList(),
                Amentity = amentity
            };
            return View(amentityViewModel);
        }

        [HttpPost]
        public IActionResult Update(AmentityViewModel amentityViewModel)
        {
            if (ModelState.IsValid)
            {
                if (amentityViewModel.Amentity != null)
                {
                    _unitOfWork.Amentity.Update(amentityViewModel.Amentity);
                    _unitOfWork.Save();
                    TempData["success"] = "Cập nhật tiện nghi thành công";
                    return RedirectToAction("Index", "Amentity");
                }
                else
                {
                    TempData["error"] = "Tiện nghi không hợp lệ";
                    return NotFound();
                }
            }

            amentityViewModel.HotelList = _unitOfWork.Hotel.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            }).ToList();
            return View(amentityViewModel);
        }

        public IActionResult Delete(int amentityId)
        {
            AmentityViewModel amentityViewModel = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }),
                Amentity = _unitOfWork.Amentity.Get(h => h.Id == amentityId)
            };
            if (amentityViewModel.Amentity == null)
            {
                TempData["error"] = "Không tìm thấy tiện nghi";
                return NotFound();
            }
            return View(amentityViewModel);
        }

        [HttpPost]
        public IActionResult Delete(AmentityViewModel amentityViewModel)
        {
            Amentity? itemFromDatabase = _unitOfWork.Amentity.Get(h => h.Id == amentityViewModel.Amentity.Id);
            if (itemFromDatabase != null)
            {
                _unitOfWork.Amentity.Remove(itemFromDatabase);
                _unitOfWork.Save();
                TempData["success"] = "Xóa tiện nghi thành công";
                return RedirectToAction("Index", "Amentity");
            }
            else
            {
                TempData["error"] = "Xoá tiện nghi thất bại";
                return NotFound();
            }
        }
    }
}
