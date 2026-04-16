using PointFlow.Model;

namespace PointFlow.Web.Repositories;

public class CategoryMockRepository
{
    private readonly List<Category> _categories =
    [
        new Category
        {
            Id = 1,
            Name = "Learning",
            Description = "Tasks related to acquiring new knowledge"
        },
        new Category
        {
            Id = 2,
            Name = "Fitness",
            Description = "Tasks related to physical health and exercise"
        },
        new Category
        {
            Id = 3,
            Name = "Work",
            Description = "Professional and career-related tasks"
        }
    ];

    public List<Category> GetAll() => _categories;

    public Category? GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);
}
