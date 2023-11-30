using lab15_17.Data;
using lab15_17.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lab15_17.Controllers
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
            List<Film> films = _dbContext.Films.ToList();
            if (films.Count > 2)
            {
                Random random = new();
                int firstIndex = random.Next(films.Count);
                int secondIndex = firstIndex;
                while (secondIndex == firstIndex)
                {
                    secondIndex = random.Next(films.Count);
                }
                films = films.Where((film, index) => index == firstIndex || index == secondIndex).ToList();
            }
            ViewBag.Films = films;
            List<Hall> halls = _dbContext.Halls.ToList();
            if (films.Count > 2)
            {
                Random random = new();
                int firstIndex = random.Next(halls.Count);
                int secondIndex = firstIndex;
                while (secondIndex == firstIndex)
                {
                    secondIndex = random.Next(halls.Count);
                }
                halls = halls.Where((halls, index) => index == firstIndex || index == secondIndex).ToList();
            }
            return View(halls);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Buy(int? Id)
        {
            ViewBag.TicketId = Id ?? 0;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            _dbContext.Purchases.Add(purchase);
            _dbContext.Remove(_dbContext.Tickets.FirstOrDefault(x => x.Id == purchase.TicketId));
            _dbContext.SaveChanges();
            return "Дякуємо, " + purchase.Person + ", за купівлю";
        }
    }
}