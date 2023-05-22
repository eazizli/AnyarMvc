using AnyarMvc.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace AnyarMvc.Areas.Admin.Controllers;


    [Area("Admin")]
    public class DashboardController : Controller
    {
    private readonly AnyarDbContext _anyardb;
        public DashboardController( AnyarDbContext anyarDbContext)
        {
            _anyardb = anyarDbContext;
        }

        public IActionResult Index()
        {

            return View();
        }
    }

