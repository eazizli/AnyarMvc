using AnyarMvc.DataContext;
using AnyarMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AnyarDbContext _context;
        private readonly IWebHostEnvironment _environment;
             

        public TeamController(AnyarDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment; 
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams=await _context.Teams.ToListAsync();    
            return View(teams);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team)
        {
            if(ModelState.IsValid) 
            { 
                return View(); 
            }
            string guid= Guid.NewGuid().ToString();
            string newfilename = guid + team.Images.FileName;
            string path = Path.Combine(_environment.WebRootPath, "assets", "img", "team", newfilename);
            using(FileStream filestream=new FileStream(path, FileMode.CreateNew))
            {
                await team.Images.CopyToAsync(filestream);
            }
            Team newteam = new Team();
            newteam.ImageName = newfilename;
            newteam.Name = team.Name;
            newteam.Surname = team.Surname;
            newteam.Work=team.Work;
            await _context.AddAsync(newteam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
