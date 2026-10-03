using Blog.CoreLayer.Dtos.Posts;
using Blog.DataLayer.Entyties;
using Blog.DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.CoreLayer.Services.User;

namespace Blog.CoreLayer.Mpperes
{
    public class PostMapper
    {
        public static Post MapCreateDtpToPost(CreatePostDto create)
        {
            return new Post
            {
                Description = create.Description,
                IsDelete = false,
                Slug = create.Slug,
                Title = create.Title,
                Visit = 0,
                Time = DateTime.Now,
                UserId = create.UserId,
                CategoryId = create.CategoryId,
                SubCategoryID = create.SubCategoryID,
                IsSpecial = create.IsSpecial,                
            };
        }

        public static Post MapEditDtoToPost(Post post, EditPostDto editPostDto)
        {
            post.Slug = editPostDto.Slug;
            post.Description = editPostDto.Description;
            post.Title = editPostDto.Title;
            post.CategoryId = editPostDto.CategoryId;
            post.SubCategoryID = editPostDto.SubCategoryID;
            post.IsSpecial = editPostDto.IsSpecial;
            return post;
        }
        public static PostDto MapGetDtoToPost(Post post)
        {
            return new PostDto
            {
                UserId = post.UserId,
                Slug = post.Slug,
                Description = post.Description,
                CategoryId = post.CategoryId,
                Title = post.Title,
                NameUser = post.User?.UserName,
                Visit = post.Visit,
                Time = post.Time,
                category = post.Category == null ? null : CategoryMapper.MapToDto(post.Category),
                ImageName = post.ImageName,
                ID = post.ID,
                SubCategoryID = post.SubCategoryID,
                SubCategory = post.Subcategory == null ? null : CategoryMapper.MapToDto(post.Subcategory),
                IsSpecial = post.IsSpecial,
            };
        }
    }
}
