using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpApp.Data;
using HttpApp.Dtos;
using HttpApp.Dtos.Stock;
using HttpApp.interfaces;
using HttpApp.Mapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpApp.Controllers{

    [Microsoft.AspNetCore.Mvc.Route("/api/stock/")]
    [ApiController]
    public class StockController : ControllerBase {

        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockrepo;
        public StockController(ApplicationDBContext applicationDbContext, IStockRepository stockrepo)
        {
            _context = applicationDbContext;
            _stockrepo = stockrepo;
        }

        [HttpGet("/test")]
        public IActionResult testRes(){
            return Ok("Helll");
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> getbyId([FromRoute] int id){
            var stock  = await  _stockrepo.FindAsync(id);
            if(stock == null){
                return NotFound();
            }

            return Ok(stock);
        }


        [HttpGet]
        public async Task<IActionResult> getAll(){
          var stocks = await _stockrepo.GetAllAsync();
          var dtos = stocks.Select(s=>s.toStockDto())   ;
            return Ok(stocks);
        }


        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateStockRequestDto createStockRequestDto){

                var stockModel = StockMapper.toStockFromCreateStockRequest(createStockRequestDto);
                await _stockrepo.createAsync(stockModel);

                return CreatedAtAction(nameof(getbyId),new {id = stockModel.Id}, stockModel.toStockDto());
        }
 

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteStock([FromRoute] int id){

            var stock = await _stockrepo.deleteAsync(id);
            if(stock  == null){
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public async Task<IActionResult> updateStock([FromRoute] int id , [FromBody] UpdateStockRequestDto updateStockRequestDto){

            var stockModel = await _stockrepo.updateAsync(id,updateStockRequestDto);
            if(stockModel == null){
                return NotFound();
            }
            return Ok(StockMapper.toStockDto(stockModel));
            
        }

        
    }
        
 }
