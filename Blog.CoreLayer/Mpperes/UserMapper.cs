using Blog.CoreLayer.Dtos.User;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Mpperes
{
    public static class UserMapper
    {
        public static User MapToUser(User user, EditUserDto editUser)
        {
            user.FullName = editUser.FullNmae;
            user.UserName = editUser.UserName;
            user.ID = editUser.UserId;
            user.Role = editUser.Role;               
            return user;
        }
        public static UserDto MapToFilterUser(User user)
        {
            return new UserDto()
            {
                FullName = user.FullName,
                Role = user.Role,
                UserName = user.UserName,
                UserId = user.ID,
            };
        }

    }
}
