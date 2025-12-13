using BookStoreWeb.Common;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data;

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
                    Name = "Action", DisplayOrder = 1
                },
                new Category()
                {
                    Name = "Sci-fi", DisplayOrder = 2
                },
                new Category()
                {
                    Name = "History", DisplayOrder = 3
                }
            );
        modelBuilder.Entity<Category>().Property<RecordState>("RecordState").HasConversion<string>().HasMaxLength(50);
    }
}