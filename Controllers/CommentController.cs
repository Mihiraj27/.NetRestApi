using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpApp.Data;
using HttpApp.Dtos.Stock.Comment;
using HttpApp.Interfaces;
using HttpApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HttpApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _commentrepo;


        public CommentController(ApplicationDBContext context , ICommentRepository commentrepo )
        {
            _context = context;
            _commentrepo = commentrepo;   
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll(){

            var commentList =  await _commentrepo.getAllComment();
          
            if(commentList == null){
                return NotFound();
            }

            return Ok(commentList);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("findById/{id}")]
        public async Task<IActionResult> findById(int id){
            var comment = await _commentrepo.getComment(id);
            if(comment == null){
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("deleteComment/{id}")]
        public async Task<IActionResult> deleteComment(int id){
            
             var comment = await _commentrepo.deleteComment(id);
            if(comment  == null){
                return NotFound();
            }
            return NoContent();

        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("updateComment/{id}")]
        public async Task<IActionResult> updateComment([FromRoute] int id , [FromBody]UpdateCommentRequestDto updateCommentRequestDto){

            var updateComment = await _commentrepo.updateComment(id,updateCommentRequestDto);
            Console.WriteLine("ddd "+updateCommentRequestDto.Content);
              Console.WriteLine("ddd "+updateCommentRequestDto.CreatedOn);
                Console.WriteLine("ddd "+updateCommentRequestDto.Title);
            if(updateComment == null){
                return NoContent();
            }

            return Ok(updateComment);


        }
         

    }


}