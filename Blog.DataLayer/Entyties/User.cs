using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entyties
{
    public class User:BaseEntity<int>
    {
        [Required]
        [MaxLength(300)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<PostCoamment> PostComments { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}

