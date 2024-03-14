using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;
using Swarojgaar.Models;

namespace Swarojgaar.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }
        public IActionResult Index()
        {
            var categories = _dbSet.AsNoTracking().ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _dbSet.Add(category);
            _context.SaveChanges();
            TempData["ResultOk"] = "Category Created Successfully !";
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Edit(int categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }
            var category = _dbSet.Find(categoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(category).State = EntityState.Modified;
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Category updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(category);
        }

        private bool CategoryExists(int id)
        {
            return _dbSet.Any(e => e.CategoryId == id);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var category = _dbSet.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _dbSet.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbSet.Remove(category);
            _context.SaveChanges();
            TempData["ResultOk"] = "Category deleted successfully!";
            return RedirectToAction(nameof(Index));
        }


    }
}
