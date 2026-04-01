namespace PointFlow.Model;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // N-N: Tag <-> PointTask
    public List<PointTask> Tasks { get; set; } = [];
}
