using Blog.CoreLayer.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos
{
   public class MainPageDto
   {
        public List<PostDto> LatesPost { get; set; }
        public List<PostDto> SpecialPosts { get; set; }
        public List<MainPageCategoryDto> Categories { get; set; }
    }
    public class MainPageCategoryDto
    {
        public bool IsMainCategory { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public int PostChild { get; set; }
    }
}
