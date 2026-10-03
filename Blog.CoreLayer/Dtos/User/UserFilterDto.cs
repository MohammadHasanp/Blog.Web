using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Entyties;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Dtos.User
{
    public class UserFilterDto:BacePagination
    {
        public List<UserDto> Users { get; set; }
        public  UserFilter UserFilter{ get; set; }

    }
    public class UserFilter
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string FullName{ get; set; }
        public string  UserName { get; set; }
        public UserRole Role { get; set; }

    }
}
