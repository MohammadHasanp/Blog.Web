using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Mpperes;
using Blog.CoreLayer.Services.FileManager;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entyties;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Blog.CoreLayer.Services.Posts
{
    public class Postservices : IPostServices
    {
        private readonly BlogContext _Db;
        private readonly IFileManager _fileManager;
        public Postservices(BlogContext context, IFileManager file)
        {
            _Db = context;
            _fileManager = file;
        }
        public OperationResult CreatePost(CreatePostDto createPostDto)
        {
            if (createPostDto.ImageFile == null)
                return OperationResult.Error();
            var post = PostMapper.MapCreateDtpToPost(createPostDto);

            if (IsSlugExist(post.Slug))
                return OperationResult.Error("Slug تکراری است");

            post.ImageName = _fileManager.SaveImageName(createPostDto.ImageFile, Directories.PostImage);
            _Db.Posts.Add(post);
            _Db.SaveChanges();

            return OperationResult.Success();
        }

        public OperationResult Editpost(EditPostDto editPostDto)
        {
            var post = _Db.Posts.FirstOrDefault(c => c.ID == editPostDto.ID);
            if (post == null)
                return OperationResult.NotFound();

            var oldImage = post.ImageName;
            var newSlug = editPostDto.Slug.ToSlug();

            if (post.Slug != newSlug)
                if (IsSlugExist(newSlug))
                    return OperationResult.Error("Slug تکراری است");

            PostMapper.MapEditDtoToPost(post, editPostDto);
            if (editPostDto.imageFile != null)
                post.ImageName = _fileManager.SaveFile(editPostDto.imageFile, Directories.PostImage);

            _Db.SaveChanges();
            if (editPostDto.imageFile != null)
                _fileManager.SaveFile(editPostDto.imageFile, Directories.PostImage);

            return OperationResult.Success();
        }

        public List<PostDto> GetPopularPost()
        {
            return _Db.Posts
                .Include(p => p.User)
                .OrderByDescending(p => p.Visit)
                .Take(6)
                .Select(post => PostMapper.MapGetDtoToPost(post)).ToList();
        }
        public PostDto GetPost(int id)
        {
            var post = _Db.Posts.Include(p => p.Category).Include(p => p.Subcategory).FirstOrDefault(p => p.ID == id);
            return PostMapper.MapGetDtoToPost(post);
        }
        public PostDto GetPostBySlug(string slug)
        {
            var post =
                _Db.Posts.Include(p => p.Category)
                .Include(p => p.Subcategory)
                .Include(p => p.User)
                .FirstOrDefault(p => p.Slug == slug);
            if (post == null)
            {
                return null;
            }
            return PostMapper.MapGetDtoToPost(post);
        }

        public List<PostDto> GetRelatedPosts(int CategoryID)
        {
            return _Db.Posts
                .Where(p => p.CategoryId == CategoryID || p.SubCategoryID == CategoryID)
                .OrderBy(p => p.SubCategoryID)
                .Take(6).Select(post => PostMapper.MapGetDtoToPost(post)).ToList();
        }

        public void Increasevisits(int PostId)
        {
            var Post = _Db.Posts.First(p => p.ID == PostId);
            Post.Visit += 1;
            _Db.SaveChanges();
        }

        public bool IsSlugExist(string slug)
        {
            return _Db.Posts.Any(p => p.Slug == slug.ToSlug());
        }

        public PostFilterDto PostFilterDto(PostFilterParams postFilterParams)
        {
            var Result = _Db.Posts
                .Include(d=>d.User)
                .Include(d => d.Category)
                .Include(d => d.Subcategory)
                .OrderByDescending(d => d.Time)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(postFilterParams.Slug))
            {
                Result = Result.Where(p => p.Category.Slug == postFilterParams.Slug
                || p.Subcategory.Slug == postFilterParams.Slug);
            }
            if (!string.IsNullOrWhiteSpace(postFilterParams.Title))
            {
                Result = Result.Where(p => p.Title == postFilterParams.Title);
            }
            var skip = (postFilterParams.PageId - 1) * postFilterParams.Take;
            var PageCount = Result.Count() / postFilterParams.Take;
            var modal = new PostFilterDto
            {
                Posts = Result.Skip(skip).Take(postFilterParams.Take).Select(post => PostMapper.MapGetDtoToPost(post)).ToList(),
                FilterParams = postFilterParams,
            };
            modal.GeneratePaging(Result,postFilterParams.Take,postFilterParams.PageId);
            return modal; 
        }
    }
}
