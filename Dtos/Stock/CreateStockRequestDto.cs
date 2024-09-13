using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HttpApp.Dtos
{
    public class CreateStockRequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string Symbol { get; set;} 
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public decimal Purchase { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public decimal LastDev { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public long MarketCap  { get; set; }

    }
}