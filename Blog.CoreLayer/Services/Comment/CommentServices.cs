using Blog.CoreLayer.Dtos.Comment;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entyties;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Comment
{
    public class CommentServices : ICommentServices
    {
        private readonly BlogContext _context;

        public CommentServices (BlogContext db)
        {
            _context = db;
        }
        public OperationResult CreateComment(CreateCommentDto createComment)
        {
            var comment = new PostCoamment()
            {
                PostId = createComment.PostId,
                UserId = createComment.UserId,
                Text = createComment.Text,
            };

            _context.Add(comment);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CommentDto> GetComments(int PostId)
        {
            return _context.PostCoamments
                .Include(c=>c.User)
                .Where(comment =>comment.PostId==PostId)
                .Select(comment =>new CommentDto()
            {
                PostId = comment.PostId,
                UserFullName = comment.User.FullName,
                Text = comment.Text,
                CommentId = comment.ID,
                Time = comment.Time,
            }).ToList();
        }
    }
}
