using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Dtos.User;
using Blog.CoreLayer.Mpperes;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entyties;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Blog.CoreLayer.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly BlogContext db;
        public UserServices(BlogContext context)
        {
            db = context;
        }

        public OperationResult EditUser(EditUserDto editUserDto)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == editUserDto.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            UserMapper.MapToUser(user,editUserDto);
            db.SaveChanges();
            return OperationResult.Success();
        }



        public UserDto LoginUser(LoginUserDto userDto)
        {
            var Passwordhashed = userDto.Password.EncodeToMd5();
            var User = db.Users.FirstOrDefault(u => u.UserName == userDto.UserName && u.Password == Passwordhashed);
            if (User == null)
                return null;
            
            var UserDto = new UserDto()
            {
                FullName = User.FullName,
                UserName = User.UserName,
                Role = User.Role,
                Password = User.Password,
                RegisterDate = User.Time,
                UserId = User.ID,
            };
            return UserDto;

        }

        public OperationResult RegisterUser(UserRegisterDto RegisterDto)
        {
            var IsUserNameExist = db.Users.Any(u => u.UserName == RegisterDto.UserName);
            if (IsUserNameExist)
                return OperationResult.Error(" تکراری است");


            else
            {
                var PasswordHash = RegisterDto.Password.EncodeToMd5();
                db.Users.Add(new Blog.DataLayer.Entyties.User
                {
                    FullName = RegisterDto.FullName,
                    IsDelete = false,
                    UserName = RegisterDto.UserName,
                    Role = UserRole.User,
                    Time = DateTime.Now,
                    Password = PasswordHash,
                });
                db.SaveChanges();
                return OperationResult.Success();
            }
        }

        public UserFilterDto UserFilterDto(UserFilter userFilter) 
        {
            var res = db.Users.OrderByDescending(u => u.Time).AsQueryable();
            if (!string.IsNullOrWhiteSpace(userFilter.FullName))
            {
                res = res.Where(u => u.FullName == userFilter.FullName);
            }
            if (!string.IsNullOrWhiteSpace(userFilter.UserName))
            {
                res = res.Where(u => u.UserName == userFilter.UserName);
            }
            var skip = (userFilter.PageId - 1) * userFilter.Take;
            var PageCount = res.Count() / userFilter.Take;
            var model = new UserFilterDto()
            {
                Users = res.Skip(skip).Take(userFilter.Take).Select(user => UserMapper.MapToFilterUser(user)).ToList(),
                UserFilter = userFilter
            };
            model.GeneratePaging(res,userFilter.Take,userFilter.PageId);
            return model;
        }
        UserDto IUserServices.GetUserById(int userid)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == userid);
            if (user == null)
            {
                return null;
            }
            return new UserDto()
            {

                FullName = user.FullName,
                Role = user.Role,
                UserName = user.UserName,
                Password = user.Password,
                RegisterDate = user.Time,
                UserId = user.ID,
            };
        }
    }
}
