using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpApp.Dtos.Stock;
using HttpApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpApp.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

        Task<Stock?> FindAsync(int id);

        Task<Stock> createAsync(Stock stock);

        Task<Stock?> updateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

        Task<Stock?> deleteAsync(int id);
    }
}