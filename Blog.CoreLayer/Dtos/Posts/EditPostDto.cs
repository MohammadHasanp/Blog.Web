using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos.Posts
{
    public class EditPostDto
    {
        public int ID { get; set; }
        public int? SubCategoryID { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool IsSpecial { get; set; }
        public string Description { get; set; }
        public IFormFile? imageFile { get; set; }
    }
}
