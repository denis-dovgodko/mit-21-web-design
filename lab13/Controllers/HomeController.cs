using lab13.Data;
using lab13.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab13.Controllers
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
            IEnumerable<Ticket> tickets = _dbContext.Tickets;
            ViewBag.Tickets = tickets;
            return View();
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ticket != null)
            {
                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Buy(int? Id) {
            ViewBag.BookId = Id ?? 0;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase) {
            purchase.Date = DateTime.Now;
            _dbContext.Purchases.Add(purchase);
            _dbContext.SaveChanges();
            return "Дякуємо за покупку, " + purchase.Person + ". З нетерпінням чекаємо на сеансі!";
        }
    }
}