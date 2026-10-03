using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.CoreLayer.Dtos.Posts
{
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Time { get; set; }
        public bool IsSpecial { get; set; }
        public string Description { get; set; }
        public int? SubCategoryID { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
