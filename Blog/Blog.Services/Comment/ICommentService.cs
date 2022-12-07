using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comment
{
    public interface ICommentService
    {
        Task<IEnumerable<Core.DTOs.CommentDto>> GetCommentsFromPost(string slug);
        Task<Core.DTOs.CommentDto> CreateCommentForPost(string slug, Core.DTOs.CommentCreateDto commentDto);
        Task DeleteCommentFromPost(string slug, int commentId);
    }
}
