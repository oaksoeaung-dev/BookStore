using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(IUnitOfWork unitOfWork) : Controller
{

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var categoryList = await unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return View(categoryList);
    }

    public IActionResult Create()
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
            await unitOfWork.CategoryRepository.AddAsync(newCategory, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            
            TempData["success"] = "Successfully created.";
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id.ToString()))
        {
            return NotFound();
        }

        Category? categoryFromDb = await unitOfWork.CategoryRepository.GetAsync(category => category.Id == id, cancellationToken);
        if (categoryFromDb is null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            category.ModifiedAt = DateTime.UtcNow;
            unitOfWork.CategoryRepository.Update(category);
            await unitOfWork.SaveAsync(cancellationToken);
            
            TempData["success"] = "Successfully updated.";
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await unitOfWork.CategoryRepository.GetAsync(category => category.Id == id, cancellationToken);
        if (category is not null)
        {
            category.RecordState = RecordState.Deleted;
            category.ModifiedAt = DateTime.UtcNow;
            unitOfWork.CategoryRepository.Update(category);
            
            TempData["success"] = "Successfully deleted.";
            await unitOfWork.SaveAsync(cancellationToken);
        }
        return RedirectToAction("Index");
    }
}