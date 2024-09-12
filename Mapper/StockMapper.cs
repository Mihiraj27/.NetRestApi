using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HttpApp.Dtos.Stock;
using HttpApp.Models;

namespace HttpApp.Mapper
{
    public static class StockMapper
    {

        public static StockDto toStockDto(this Stock stockModel){
           return new StockDto{
            
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase
           
            
           };
        }
        
    }
}