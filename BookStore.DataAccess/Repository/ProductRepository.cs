using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;

namespace BookStore.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public void Update(Product product)
    {
        var objFromDb = _context.Products.FirstOrDefault(p => p.Id == product.Id);

        if (objFromDb != null)
        {
            objFromDb.Title = product.Title;
            objFromDb.Description = product.Description;
            objFromDb.Price = product.Price;
            objFromDb.ISBN = product.ISBN;
            objFromDb.ListPrice = product.ListPrice;
            objFromDb.CategoryId = product.CategoryId;
            objFromDb.Author = product.Author;
            objFromDb.Price50 = product.Price50;
            objFromDb.Price100 = product.Price100;

            if (product.ImageUrl != null)
            {
                objFromDb.ImageUrl = product.ImageUrl;
            }
        }
    }
}