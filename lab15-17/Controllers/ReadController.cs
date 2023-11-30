using lab15_17.Data;
using lab15_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace lab15_17.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ReadController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Sessions(int? filmId, int? hallId)
        {
            IQueryable<Session> sessions = _dbContext.Sessions;
            if (filmId != null)
            {
                sessions = sessions
                    .Where(x => x.Film.Id == filmId)
                    .Include(x => x.Film);
                ViewBag.PageTitle = $"Доступні сеанси фільму {_dbContext.Films.FirstOrDefault(x => x.Id == filmId).Name}";
            }
            else
            {
                sessions = sessions
                    .Where(x => x.Hall.Id == hallId)
                    .Include(x => x.Hall);
                ViewBag.PageTitle = $"Доступні сеанси для залу {_dbContext.Halls.FirstOrDefault(x => x.Id == hallId).HallName}";
            }
            return View(sessions.ToList());
        }
        public ActionResult Films()
        {
            IEnumerable<Film> films = _dbContext.Films;
            return View(films);
        }
        public ActionResult Halls()
        {
            IEnumerable<Hall> halls = _dbContext.Halls;
            return View(halls);
        }
        public ActionResult Tickets(int? sessionId)
        {
            IEnumerable<Ticket> tickets = _dbContext.Tickets
                .Where(x => x.Session.Id == sessionId)
                .Include(x => x.Session);
            return View(tickets);
        }
        public ActionResult Index()
        {
            List<Hall> halls = _dbContext.Halls.ToList();
            ViewBag.Films = _dbContext.Films.ToList();
            return View(halls);
        }
    }
}
