using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class TagMockRepository
{
    private readonly List<Tag> _tags =
    [
        new Tag { Id = 1, Name = "Study" },
        new Tag { Id = 2, Name = "Work" },
        new Tag { Id = 3, Name = "Health" },
        new Tag { Id = 4, Name = "Personal" }
    ];

    public List<Tag> GetAll() => _tags;

    public Tag? GetById(int id) => _tags.FirstOrDefault(t => t.Id == id);
}
