using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entyties
{
    public class Category:BaseEntity<int>
    {
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Slug { get; set; }
        [MaxLength(100)]
        public string MetaTag { get; set; }
        [MaxLength(100)]
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }

        [InverseProperty("Category")]
        public ICollection<Post> Posts { get; set; }

        [InverseProperty("Subcategory")]
        public ICollection<Post> SubPosts { get; set; }
    }
}
