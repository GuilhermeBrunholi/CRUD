using Microsoft.AspNetCore.Mvc;
using module4.Domain;
using module4.Controllers;
using module4.Data;
using System.Linq;

namespace module4.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var categories = _context.Category.ToList();
            ViewBag.category = categories;

            var categorySelected = _context.Category.FirstOrDefault(c => c.Id == id);

            return View(categorySelected);
        }

        [HttpPost]
        public IActionResult Register(Category category)
        {
            if (category.Id == 0)
            {
                _context.Category.Add(category);
            }
            else
            {
                var categorySaved = _context.Category.FirstOrDefault(c => c.Id == category.Id);
                categorySaved.Name = category.Name;
                _context.Category.Update(categorySaved);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categorySelected = _context.Category.FirstOrDefault(c => c.Id == id);
            _context.Category.Remove(categorySelected);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}