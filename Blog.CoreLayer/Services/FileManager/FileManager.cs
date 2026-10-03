using Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public void DeleteFile(string path, string filename)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), path, filename);
            if (File.Exists(folderpath))
            {
                File.Delete(folderpath);
            }
        }

        public string SaveFile(IFormFile file, string SavePath)
        {
            if (file == null)
                return null;

            var FileName = $"{Guid.NewGuid()}{file.FileName}";
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), SavePath.Replace("/", "\\"));
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            var fullpath = Path.Combine(folderpath,FileName);
            using (var stram = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stram);
            }
            return FileName;
        }

        public string SaveImageName(IFormFile file, string ImageName)
        {
            var isNotImage = !ImageValidation.Validate(file.FileName);
            if(isNotImage)
            {
                throw new Exception();
            }
            return SaveFile(file,ImageName);
        }
    }
}
