using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Utilities
{
    public class ImageValidation
    {
        public static bool Validate(string imageNmae)
        {
            if (imageNmae == null)
            {
                return false;
            }

            var extension = Path.GetExtension(imageNmae);
            return extension.ToLower() == ".jpg" || extension.ToLower() == ".png";
        }
        public static bool Validate(IFormFile file)
        {
            try
            {
                using var image = System.Drawing.Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
