using Blog.CoreLayer.Services.FileManager;
using Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;
        public UploadController(IFileManager file)
        {
            _fileManager = file;
        }
        [Route("/Upload/Article")]
        public IActionResult UploadArticle(IFormFile Upload)
        {
            if (Upload==null)
            {
                BadRequest();
            }
            var filename = _fileManager.SaveFile(Upload,Directories.PostContentImage);
            return Json(new {Uploaded = true , Url = Directories.GetPostContentImage(filename)});
        }
    }
}
