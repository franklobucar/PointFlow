using PointFlow.Model;

namespace PointFlow.Web.Models;

public class DashboardViewModel
{
    public List<AppUser> Users { get; set; } = [];
    public List<PointTask> Tasks { get; set; } = [];
    public List<Reward> Rewards { get; set; } = [];
}
