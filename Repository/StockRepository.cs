using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpApp.Data;
using HttpApp.Dtos.Stock;
using HttpApp.interfaces;
using HttpApp.Mapper;
using HttpApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpApp.Repository
{
    public class StockRepository : IStockRepository
    {

        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext contxt)
        {
            _context = contxt;
        }


        public async Task<List<Stock>> GetAllAsync()
        {
            return  await _context.Stock.ToListAsync();
        }

        public async Task<Stock> createAsync(Stock stock)
        {
                await _context.Stock.AddAsync(stock);
                await _context.SaveChangesAsync();

                return stock;
        }

        public async Task<Stock?> FindAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }

        public async Task<Stock?> updateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return null;
            }

            stockModel.CompanyName = updateStockRequestDto.CompanyName;
            stockModel.LastDev = updateStockRequestDto.LastDev;
            stockModel.Industry = updateStockRequestDto.Industry;
            stockModel.Purchase = updateStockRequestDto.Purchase;
            stockModel.Symbol = updateStockRequestDto.Symbol;
            stockModel.MarketCap = updateStockRequestDto.MarketCap;

             await _context.SaveChangesAsync();

            return stockModel;

        }

       
        public async Task<Stock?> deleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return null;
            }

            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }
    }
}