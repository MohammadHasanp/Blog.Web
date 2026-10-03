using Blog.CoreLayer.Utilities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos.Posts
{
    public class PostFilterDto:BacePagination
    {
        public List<PostDto> Posts{ get; set; }
        public PostFilterParams FilterParams { get; set; }
    }
    public class PostFilterParams
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}
