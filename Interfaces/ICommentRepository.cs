using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpApp.Dtos.Stock.Comment;
using HttpApp.Models;

namespace HttpApp.Interfaces
{
    public interface ICommentRepository
    {
        
        Task<List<Comment>> getAllComment();

        Task<Comment?> getComment(int id);

        Task<Comment?> createComment(Comment comment);

        Task<Comment?> updateComment(int id , UpdateCommentRequestDto requestDto );

        Task<Comment?> deleteComment(int id);

    }
}