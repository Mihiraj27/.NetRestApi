using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HttpApp.Dtos.Stock
{
    public class UpdateStockRequestDto
    {

        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string Symbol { get; set; }
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string CompanyName { get; set; } = string.Empty;
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public decimal Purchase { get; set; }
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public decimal LastDev { get; set; }
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public string Industry { get; set; } = string.Empty;
        [MinLength(5,ErrorMessage ="Minumum Length should be 5 Charactors")]
        [MaxLength(50, ErrorMessage ="Maximum Charactors Exceed should Be less than 5")]
        public long MarketCap  { get; set; }
    }
}