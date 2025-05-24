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
    public class HotelNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hotel_Number { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [ValidateNever]        
        public Hotel Hotel { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
