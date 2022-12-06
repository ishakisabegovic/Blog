using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comment
{
    public interface ICommentService
    {
        IEnumerable<Core.DTOs.CommentDto> GetCommentsFromPost(string slug);
        Core.DTOs.CommentDto CreateCommentForPost(string slug, Core.DTOs.CommentCreateDto commentDto);
        void DeleteCommentFromPost(string slug, int commentId);
    }
}
