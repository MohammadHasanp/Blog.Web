using Blog.CoreLayer.Dtos.Categoryes;
using Blog.DataLayer.Entyties;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos.Posts
{
    public class PostDto
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string NameUser { get; set; }
        public int CategoryId { get; set; }
        public bool IsSpecial { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public int? SubCategoryID { get; set; }
        public GetCategoryDto  SubCategory { get; set; }
        public DateTime Time { get; set; }
        public IFormFile ImageFile { get; set; }
        public GetCategoryDto category { get; set; }
    }
}
