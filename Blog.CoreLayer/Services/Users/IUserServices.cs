using Blog.CoreLayer.Dtos.User;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.User
{
    public interface IUserServices
    {
        OperationResult RegisterUser(UserRegisterDto RegisterDto);
        UserDto LoginUser(LoginUserDto userDto);
        OperationResult EditUser(EditUserDto editUserDto);
        UserFilterDto UserFilterDto(UserFilter userFilter);
        UserDto GetUserById(int userid);
    }
}
