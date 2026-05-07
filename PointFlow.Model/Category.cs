using System.ComponentModel.DataAnnotations;

namespace PointFlow.Model;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    // 1-N: Category -> PointTask
    public virtual ICollection<PointTask> Tasks { get; set; } = new List<PointTask>();
}
