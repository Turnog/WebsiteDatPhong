using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utility
{
    public static class UserRoles
    {
        public const string Role_DoangNhiep = "Doanh nghiệp";
        public const string Role_KhachHang = "Khách hàng";

        //chưa giải quyết
        public const string StatusPending = "Pending";
        //đã giải quyết
        public const string StatusApproved = "Approved";
        //đã huỷ
        public const string StatusCancelled = "Cancelled";
        //đã hoàn thành
        public const string StatusCompleted = "Completed";
        //đã hoàn tiền
        public const string StatusRefunded = "Refunded";
        //đã đăng ký
        public const string StatusCheckedIn = "CheckedIn";


    }
}
