using BookStore.Models;
using BookStore.Utility.Common;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasQueryFilter(category => category.RecordState == RecordState.Active)
            .HasData(
                new Category()
                {
                    Id = Guid.CreateVersion7(),
                    Name = "Action",
                    DisplayOrder = 1
                },
                new Category()
                {
                    Name = "Sci-fi",
                    DisplayOrder = 2
                },
                new Category()
                {
                    Name = "History",
                    DisplayOrder = 3
                }
            );
        modelBuilder.Entity<Category>().Property<RecordState>("RecordState").HasConversion<string>().HasMaxLength(50);
    }
}