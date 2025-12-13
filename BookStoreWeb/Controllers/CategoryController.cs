using BookStoreWeb.Common;
using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var categoryList = await _db.Categories.OrderBy(category => category.DisplayOrder).ToListAsync(cancellationToken);
        return View(categoryList);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category, CancellationToken cancellationToken)
    {
        //ModelState.AddModelError("displayorder", "Hello World");
        if (ModelState.IsValid)
        {
            Category newCategory = Category.Create(category.Name, category.DisplayOrder);
            await _db.Categories.AddAsync(newCategory, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            TempData["success"] = "Successfully created.";
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
        {
            return NotFound();
        }
        Category? categoryFromDb = await _db.Categories.FindAsync(id);
        if (categoryFromDb is null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category, CancellationToken cancellationToken)
    {
        //ModelState.AddModelError("displayorder", "Hello World");
        if (ModelState.IsValid)
        {
            category.ModifiedAt = DateTime.UtcNow;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync(cancellationToken);
            TempData["success"] = "Successfully updated.";
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await _db.Categories.FindAsync(id, cancellationToken);
        if (category is not null)
        {
            category.RecordState = RecordState.Deleted;
            category.ModifiedAt = DateTime.UtcNow;
            _db.Categories.Update(category);
            TempData["success"] = "Successfully deleted.";
            await _db.SaveChangesAsync(cancellationToken);
        }
        return RedirectToAction("Index");
    }
}