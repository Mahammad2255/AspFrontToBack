using AspFrontToBack.DAL;
using AspFrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspFrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Count();
            //return View(_context.Products.OrderByDescending(p=>p.Id).Take(8).ToList());
            return View();
        }
        public IActionResult LoadMore(int skip)
        {
            List<Product> model = _context.Products.Skip(skip).Take(8).ToList();
            return PartialView("_ProductPartial", model);
        }
    }
}
