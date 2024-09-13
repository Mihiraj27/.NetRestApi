using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpApp.Data;
using HttpApp.Dtos.Stock.Comment;
using HttpApp.Interfaces;
using HttpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Comment?> createComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment?> deleteComment(int id)
        {
              var existingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(existingComment == null){
                    return null;
            }

            _context.Remove(existingComment);
            await _context.SaveChangesAsync();

            return existingComment;
        }

        public async Task<List<Comment>> getAllComment()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> getComment(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
         
        }

        public async Task<Comment?> updateComment(int id,UpdateCommentRequestDto comment)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(existingComment == null){
                    return null;
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Title;
            existingComment.CreatedOn = comment.CreatedOn;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}