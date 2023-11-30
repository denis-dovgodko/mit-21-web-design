using lab15_17.Data;
using lab15_17.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab15_17.Controllers
{
    public class DeleteController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: UpdateController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Film()
        {
            ViewBag.Films = _dbContext.Films;
            return View();
        }
        [HttpPost]
        public ActionResult Film(Film film)
        {
            _dbContext.Remove(film);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Hall()
        {
            ViewBag.Halls = _dbContext.Halls;
            return View();
        }
        [HttpPost]
        public ActionResult Hall(Hall hall)
        {
            _dbContext.Remove(hall);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Session()
        {
            ViewBag.Sessions = _dbContext.Sessions;
            ViewBag.Films = _dbContext.Films;
            ViewBag.Halls = _dbContext.Halls;
            return View();
        }
        [HttpPost]
        public ActionResult Session(Session session)
        {
            _dbContext.Remove(session);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Ticket()
        {
            ViewBag.Tickets = _dbContext.Tickets;
            ViewBag.Sessions = _dbContext.Sessions;
            return View();
        }
        [HttpPost]
        public ActionResult Ticket(Ticket ticket)
        {
            _dbContext.Remove(ticket);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
