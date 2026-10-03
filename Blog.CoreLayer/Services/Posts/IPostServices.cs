using Blog.CoreLayer.Dtos.Posts;
using Blog.DataLayer.Entyties;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Posts
{
    public interface IPostServices
    {
        OperationResult CreatePost(CreatePostDto createPostDto);
        OperationResult Editpost(EditPostDto editPostDto);
        PostDto GetPostBySlug(string slug);
        PostDto GetPost(int id);
        PostFilterDto PostFilterDto(PostFilterParams postFilterParams);
        List<PostDto> GetRelatedPosts(int CategoryID);
        List<PostDto> GetPopularPost();
        void Increasevisits(int PostId);
    }
}
