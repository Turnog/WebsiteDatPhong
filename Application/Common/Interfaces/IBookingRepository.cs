using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Update(Booking entity);
        void UpdateStatus(int booking,string bookingStatus);
        void UpdateStripePaymentId(int booking,string stripeSessionId, string stripePaymentIntentId);
    }
}
