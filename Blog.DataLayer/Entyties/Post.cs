using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entyties
{
    public class Post:BaseEntity<int>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryID { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Slug { get; set; }
        [Required]
        [MaxLength(600)]
        public string Description { get; set; }
        public int Visit { get; set; }
        public string ImageName { get; set; }
        public bool IsSpecial { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }    

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("SubCategoryID")]
        public Category Subcategory { get; set; }
        
        public ICollection<PostCoamment> PostComments { get; set; }
    }
}
