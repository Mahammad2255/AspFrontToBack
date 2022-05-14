using AspFrontToBack.DAL;
using AspFrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspFrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (ModelState["Photo"].ValidationState== ModelValidationState.Invalid) return View();
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Sekil secin!");        
                
                return View();
            }
            if(slider.Photo.Length / 1024 <= 200){
                ModelState.AddModelError("Photo", "Olcu boyukdur!");

                return View();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
