using System.ComponentModel.DataAnnotations;

namespace PointFlow.Model;

public class Tag
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    // N-N: Tag <-> PointTask
    public virtual ICollection<PointTask> Tasks { get; set; } = new List<PointTask>();
}
