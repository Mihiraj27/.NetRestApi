using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; } = string.Empty;
       

        public decimal Purchase { get; set; }
       


        public decimal LastDev { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MarketCap  { get; set; }

        public List<Comment> Comments = new List<Comment>();
    }
}