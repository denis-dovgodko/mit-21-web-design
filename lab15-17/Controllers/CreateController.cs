using lab15_17.Data;
using lab15_17.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace lab15_17.Controllers
{
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Hall(Hall hall)
        {
            if(hall != null)
            {
                _dbContext.Halls.Add(hall);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Film()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Film(Film film)
        {
            if (film != null)
            {
                _dbContext.Films.Add(film);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Session()
        {
            IEnumerable<Hall> halls = _dbContext.Halls;
            ViewBag.Halls = halls;
            IEnumerable<Film> films = _dbContext.Films;
            ViewBag.Films = films;
            return View();
        }
        [HttpPost]
        public ActionResult Session(Session session)
        {
            if (session != null)
            {
                _dbContext.Sessions.Add(session);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Ticket()
        {
            IEnumerable<Session> sessions = _dbContext.Sessions;
            ViewBag.Sessions = sessions;
            IEnumerable<Hall> halls = _dbContext.Halls;
            ViewBag.Halls = halls;
            return View();
        }
        [HttpPost]
        public ActionResult Ticket(Ticket ticket)
        {
            if (ticket != null)
            {
                Session session = _dbContext.Sessions.FirstOrDefault(h => h.Id == ticket.SessionId);
                Hall hall = _dbContext.Halls.FirstOrDefault(h => h.Id == session.HallId);
                for (int i = 1; i < hall.SeatsCount + 1; i++) 
                {
                    Ticket newTicket = new Ticket
                    {
                        SessionId = ticket.SessionId,
                        Row = (((i-1) / (hall.SeatsCount / hall.RowsCount)) + 1),
                        Seat = i
                    };
                    _dbContext.Tickets.Add(newTicket);
                    _dbContext.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
