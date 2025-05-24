using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NghiepVu.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        [Display(Name = "Tên khách sạn")]
        [MaxLength(200)]    
        public required string Name { get; set; }
        public string? Description { get; set; } //mô tả
        [Display(Name = "Giá phòng một đêm")]
        [Range(10,20000)]
        public double Price { get; set; }
        public int SquareMeters { get; set; } //diện tích (m2)
        [Range(1, 10)]
        public int Occupancy { get; set; } //số người tối đa trong một phòng

        [NotMapped]
        public IFormFile? Image { get; set; } //hình ảnh

        [Display(Name = "Link hình ảnh")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; } //ngày tạo
        public DateTime? UpdatedDate { get; set; } //ngày cập nhật

        [ValidateNever]
        public IEnumerable<Amentity> HotelAmentity { get; set; } = new List<Amentity>(); //danh sách tiện nghi

        [NotMapped]
        public bool IsAvailable { get; set; } = true; //trạng thái phòng

    }
}
