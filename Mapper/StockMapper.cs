using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HttpApp.Dtos;
using HttpApp.Dtos.Stock;
using HttpApp.Models;
using Microsoft.IdentityModel.Protocols.Configuration;

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

        public static Stock toStockFromCreateStockRequest(this CreateStockRequestDto createStockRequestDto){
            return new Stock{
                    Symbol = createStockRequestDto.Symbol,
                    CompanyName  = createStockRequestDto.CompanyName,
                    Purchase = createStockRequestDto.Purchase,
                    LastDev = createStockRequestDto.LastDev,
                    Industry = createStockRequestDto.Industry,
                    MarketCap = createStockRequestDto.MarketCap

                    
            };
        }
        
    }
}