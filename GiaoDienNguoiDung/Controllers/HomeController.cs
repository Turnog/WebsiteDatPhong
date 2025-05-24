using System.Diagnostics;
using Application.Common.Interfaces;
using GiaoDienNguoiDung.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiaoDienNguoiDung.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmentity"),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
                CheckOutDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
            };
            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel)
        {
            homeViewModel.HotelList = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmentity");
            foreach (var hotel in homeViewModel.HotelList)
            {
                if (hotel.Id %2 == 0)
                {
                    hotel.IsAvailable = false;
                }    
            }
            return View(homeViewModel);
        }

        public IActionResult GetHotelByDate(int nights, DateOnly ngayNhanPhong)
        {
            //với id chẵn thì hết phòng, id lẻ thì còn
            var hotelList = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmentity").ToList();
            foreach (var hotel in hotelList)
                if (hotel.Id % 2 == 0)
                {
                    hotel.IsAvailable = false;
                }
                HomeViewModel homeViewModel = new()
                {
                    CheckInDate = ngayNhanPhong,
                    Nights = nights,
                    HotelList = hotelList,
                };
            return View(homeViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
