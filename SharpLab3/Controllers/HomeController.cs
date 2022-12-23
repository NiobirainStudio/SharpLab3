using Microsoft.AspNetCore.Mvc;
using SharpLab3.Models;
using System.Diagnostics;

namespace SharpLab3.Controllers
{
    public class HomeController : Controller
    {
        private LibraryManager libraryManager;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            libraryManager = new LibraryManager(webHostEnvironment.ContentRootPath);
        }

        public IActionResult Index()
        {
            return View(libraryManager.Albums);
        }

        public IActionResult Page(uint id)
        {
            return View("AlbumPage", libraryManager.Albums.First(g => g.Id == id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}