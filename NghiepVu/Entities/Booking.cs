using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NghiepVu.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }

        [Required] 
        public double? TotalCost { get; set; }

        public int Nights { get; set; } //số đêm
        public string? Status { get; set; } //trạng thái
        [Required]
        public DateTime BookingDate { get; set; } //ngày đặt phòng
        [Required]
        public DateOnly CheckInDate { get; set; } //ngày nhận phòng
        [Required]
        public DateOnly CheckOutDate { get; set; } //ngày trả phòng


        public bool IsPaymentSuccessful { get; set; } = false; //trạng thái thanh toán

        public DateTime PaymentDate { get; set; } //ngày thanh toán

        //phương thức thanh toán
        //ma giao dich cua thanh toan
        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; } //id của thanh toán

        public DateTime ActualCheckInDate { get; set; } //ngày thực tế nhận phòng
        public DateTime ActualCheckOutDate { get; set; } //ngày thực tế trả phòng

        public int HotelNumber { get; set; }
    }
}
