using Application.Common.Interfaces;
using Application.Common.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GiaoDienNguoiDung.Controllers
{
    public class DashboardController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        //dữ liệu giả
        readonly DateTime ngayBatDau = new(DateTime.Now.Year, DateTime.Now.Month,1);
        readonly DateTime ngayKetThuc = new(DateTime.Now.Year, DateTime.Now.Month, 1);

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LayTongDonHangChartData()
        {
            var tongDonHang = _unitOfWork.Booking.GetAll(s => s.Status != UserRoles.StatusPending || s.Status == UserRoles.StatusCancelled).Count();
            return View();
        }
    }
}
