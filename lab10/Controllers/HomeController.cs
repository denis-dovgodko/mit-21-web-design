using lab10.Data;
using lab10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CV()
        {
            return View();
        }
        public IActionResult Books()
        {
            IEnumerable<Book> books = _dbContext.Books;
            ViewBag.Books = books;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}