using AnyarMvc.DataContext;
using AnyarMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarMvc.Controllera
{
    public class HomeController : Controller
    {
        private readonly AnyarDbContext _context;

        public HomeController(AnyarDbContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            List<Team> team = await _context.Teams.ToListAsync();
            return View(team);
        }
    }
}
