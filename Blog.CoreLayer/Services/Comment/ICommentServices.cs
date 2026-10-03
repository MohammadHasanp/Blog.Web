using Blog.CoreLayer.Dtos.Comment;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Comment
{
    public interface ICommentServices
    {
        OperationResult CreateComment(CreateCommentDto createComment);

        List<CommentDto> GetComments(int PostId);
    }
}
