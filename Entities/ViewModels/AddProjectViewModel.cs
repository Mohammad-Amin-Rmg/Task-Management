namespace Entities.ViewModels;

public class AddProjectViewModel
{
    public List<int> Users { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}