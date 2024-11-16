using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public CategoryController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var categories = _dbContext.Categories.ToList();
        
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Name cannot exctly match the Display Order");
        }
        if (ModelState.IsValid)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category created successfully.";
            return RedirectToAction("Index","Category");
        }
        
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? category = _dbContext.Categories.FirstOrDefault(category => category.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The Name cannot exctly match the Display Order");
        }
        if (ModelState.IsValid)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category edited successfully.";
            return RedirectToAction("Index","Category");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Category? category = _dbContext.Categories.FirstOrDefault(category => category.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Delete(Category category)
    {
        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();
        TempData["success"] = "Category deleted successfully.";
        return RedirectToAction("Index","Category");
    }
}