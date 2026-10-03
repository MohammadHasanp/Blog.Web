using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entyties
{
    public class PostCoamment:BaseEntity<int>
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
