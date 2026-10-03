using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Services.Comment;
using Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.CoreLayer.Dtos.Comment;
using Blog.CoreLayer.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;

namespace Blog.Web.Pages
{
    [ValidateAntiForgeryToken]
    public class PostModel : PageModel
    {
        private readonly IPostServices _postServices;
        private readonly ICommentServices _comment;
        public PostModel(IPostServices services, ICommentServices commentServices)
        {
            _postServices = services;
            _comment = commentServices;
        }
        public PostDto Post { get; set; }
        #region propOnPost
        [BindProperty]
        [Required(ErrorMessage = "Pleas Enter Text")]
        public string Text { get; set; }
        [Required]
        [BindProperty]
        public int PostId { get; set; }

        public List<CommentDto> comments { get; set; }
        public List<PostDto> RelatedPost { get; set; }
        #endregion
        public IActionResult OnGet(string slug)
        {
            Post = _postServices.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();

            comments = _comment.GetComments(Post.ID);
            RelatedPost = _postServices.GetRelatedPosts(Post.SubCategoryID ?? Post.CategoryId);
            _postServices.Increasevisits(Post.ID);
            return Page();
        }

        public IActionResult OnPost(string slug)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("Post", new { slug });

            if (!ModelState.IsValid)
            {
                Post = _postServices.GetPostBySlug(slug);
                comments = _comment.GetComments(Post.ID);
                RelatedPost = _postServices.GetRelatedPosts(Post.SubCategoryID ?? Post.CategoryId);
                return Page();
            }
            _comment.CreateComment(new CreateCommentDto()
            {
                PostId = PostId,
                Text = Text,
                UserId = User.GetUserId()
            });
            return RedirectToPage("Post", new { slug });
        }
    }
}
