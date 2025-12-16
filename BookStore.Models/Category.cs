using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Category : EntityBase
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Required]
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 - 100")]
    public int DisplayOrder { get; set; }

    public Category()
    {

    }

    public Category(string name, int displayOrder)
    {
        Name = name;
        DisplayOrder = displayOrder;
    }

    public static Category Create(string name, int displayOrder)
    {
        return new(name, displayOrder);
    }

    public Category Update(string name, int displayOrder)
    {
        Name = name;
        DisplayOrder = displayOrder;
        ModifiedAt = DateTime.UtcNow;
        return this;
    }
}