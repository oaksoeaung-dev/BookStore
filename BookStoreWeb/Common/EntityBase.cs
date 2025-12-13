using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Common;

public abstract class EntityBase
{
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public RecordState RecordState { get; set; } = RecordState.Active;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}