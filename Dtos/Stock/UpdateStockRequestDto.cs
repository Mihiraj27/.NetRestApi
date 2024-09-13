using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpApp.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDev { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap  { get; set; }
    }
}