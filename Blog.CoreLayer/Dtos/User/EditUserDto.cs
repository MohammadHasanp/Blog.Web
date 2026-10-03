using Blog.DataLayer.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos.User
{
    public class EditUserDto
    {
        public int UserId { get; set; }
        public string FullNmae { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
    }
}
