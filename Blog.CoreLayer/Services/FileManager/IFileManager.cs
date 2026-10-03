using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.FileManager
{
    public interface IFileManager
    {
        string SaveFile(IFormFile file,string SavePath);
        void DeleteFile(string path,string filename);
        string SaveImageName(IFormFile file,string ImageName);
    }
}
