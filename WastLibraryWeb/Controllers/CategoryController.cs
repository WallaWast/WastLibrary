using Microsoft.AspNetCore.Mvc;
using WastLibrary.DataAccess.Repository.IRepository;
using WastLibrary.Models;

namespace WastLibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var categories = _repository.GetAll();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _repository.Add(category);
                _repository.Save();
                TempData.Add("success", "Category created successfully");

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _repository.GetFirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _repository.Update(category);
                _repository.Save();
                TempData.Add("success", "Category updated successfully");

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _repository.GetFirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var categoryFromDb = _repository.GetFirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _repository.Remove(categoryFromDb);
            _repository.Save();
            TempData.Add("success", "Category deleted successfully");

            return RedirectToAction("Index");
        }
    }
}
