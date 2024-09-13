using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpApp.Data;
using HttpApp.Dtos;
using HttpApp.Dtos.Stock;
using HttpApp.Mapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace HttpApp.Controllers{

    [Microsoft.AspNetCore.Mvc.Route("/api/stock/")]
    [ApiController]
    public class StockController : ControllerBase {

        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet("/test")]
        public IActionResult testRes(){
            return Ok("Helll");
        }



        [HttpGet("{id}")]
        public IActionResult getbyId([FromRoute] int id){
            var stock  = _context.Stock.Find(id);
            if(stock == null){
                return NotFound();
            }

            return Ok(stock);
        }


        [HttpGet]
        public IActionResult getAll(){
          var stocks = _context.Stock.ToList() 
           .Select(s=>s.toStockDto());
            return Ok(stocks);
        }


        [HttpPost]
        public IActionResult create([FromBody] CreateStockRequestDto createStockRequestDto){

                

                var stockModel = StockMapper.toStockFromCreateStockRequest(createStockRequestDto);

               // var stockModel = createStockRequestDto.toStockFromCreateStockRequest();

                _context.Stock.Add(stockModel);
                _context.SaveChanges();

                return CreatedAtAction(nameof(getbyId),new {id = stockModel.Id}, stockModel.toStockDto());
        }
 

        [HttpDelete("{id}")]
        public IActionResult deleteStock([FromRoute] int id){

            var stock = _context.Stock.FirstOrDefault(x=> x.Id == id);
            if(stock  == null){
                return NotFound();
            }

            _context.Stock.Remove(stock);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        public IActionResult updateStock([FromRoute] int id , [FromBody] UpdateStockRequestDto updateStockRequestDto){

            var stockModel = _context.Stock.FirstOrDefault(x => x.Id == id);
            if(stockModel == null){
                return NotFound();
            }

            stockModel.CompanyName = updateStockRequestDto.CompanyName;
            stockModel.LastDev = updateStockRequestDto.LastDev;
            stockModel.Industry = updateStockRequestDto.Industry;
            stockModel.Purchase = updateStockRequestDto.Purchase;
            stockModel.Symbol = updateStockRequestDto.Symbol;
            stockModel.MarketCap = updateStockRequestDto.MarketCap;

            _context.SaveChanges();

            return Ok(StockMapper.toStockDto(stockModel));
            

        }

        
    }
        
 }
