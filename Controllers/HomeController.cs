
using AspFrontToBack.DAL;
using AspFrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspFrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Caption = _context.Captions.FirstOrDefault(),
                Categories = _context.Categories.ToList(),
                Products = _context.Products.Include(p=>p.Category).ToList(),
                About = _context.About.FirstOrDefault()

            };
            return View(homeVM);
        }
    }
}
