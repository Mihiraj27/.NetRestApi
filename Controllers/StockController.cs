using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpApp.Data;
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


        [HttpGet]
        public IActionResult getAll(){
            var stocks = _context.Stock.ToList();
            return Ok(stocks);
        }
    }
        
 }
