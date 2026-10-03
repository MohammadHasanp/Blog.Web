using Blog.CoreLayer.Dtos;
using Blog.CoreLayer.Dtos.Posts;
using Blog.DataLayer.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Mainpage
{
    public interface IMainPageService
    {
        MainPageDto GetData();
        //string  GetUserNameByIdPost(int id);
    }
}
