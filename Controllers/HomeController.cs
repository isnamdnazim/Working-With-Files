using Files.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Files.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _hostingEnvironment;
        public string _dir;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _dir = _hostingEnvironment.ContentRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SingleFile(IFormFile file)
        {

            using (var fileStream = new FileStream(Path.Combine(_dir,"file.jpg"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return RedirectToAction("Index");
        }

        public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
        {
            int i = 0;
            foreach(var file in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, $"file{i}.jpg"), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                i++;
            }
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}