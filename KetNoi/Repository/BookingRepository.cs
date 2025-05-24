using Application.Common.Interfaces;
using Application.Common.Utility;
using KetNoiDB.Data;
using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoi.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Booking entity)
        {
            _db.Bookings.Update(entity);
        }

        public void UpdateStatus(int booking, string bookingStatus)
        {
            var bookingFromDatabase = _db.Bookings.FirstOrDefault(b => b.Id == booking);
            if (bookingFromDatabase != null)
            {
                bookingFromDatabase.Status = bookingStatus;
                if (bookingStatus == UserRoles.StatusCheckedIn)
                {
                    bookingFromDatabase.ActualCheckInDate = DateTime.Now;
                }
                else if (bookingStatus == UserRoles.StatusCompleted)
                {
                    bookingFromDatabase.ActualCheckOutDate = DateTime.Now;
                }
            }
        }

        public void UpdateStripePaymentId(int booking, string stripeSessionId, string stripePaymentIntentId)
        {
            var bookingFromDatabase = _db.Bookings.FirstOrDefault(b => b.Id == booking);
            if (bookingFromDatabase != null)
            {
                if (!string.IsNullOrEmpty(stripeSessionId))
                {
                    bookingFromDatabase.StripeSessionId = stripeSessionId;
                }
                if (!string.IsNullOrEmpty(stripePaymentIntentId))
                {
                    bookingFromDatabase.StripePaymentIntentId = stripePaymentIntentId;
                    bookingFromDatabase.PaymentDate = DateTime.Now;
                    bookingFromDatabase.IsPaymentSuccessful = true;
                }
            }    
        }
    }
}

