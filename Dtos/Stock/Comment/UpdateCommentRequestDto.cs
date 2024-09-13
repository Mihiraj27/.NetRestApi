using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpApp.Dtos.Stock.Comment
{
    public class UpdateCommentRequestDto
    {
         public string Title { get; set;}

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}