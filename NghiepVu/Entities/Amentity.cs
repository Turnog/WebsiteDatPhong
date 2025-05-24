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
    public class Amentity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; } //Tên tiện nghi
        public string? Description { get; set; } //Mô tả tiện nghi

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [ValidateNever]
        public Hotel Hotel { get; set; }
    }
}
