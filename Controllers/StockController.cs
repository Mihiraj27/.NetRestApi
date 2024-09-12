using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpApp.Data;
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
            var stocks = _context.Stock.ToList();
          //  .Select(s=>s.toStockDto());
            return Ok(stocks);
        }
    }
        
 }
