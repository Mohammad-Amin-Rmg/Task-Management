using Data.Repositories.Contract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementApp.Pages.Project;

public class Show : PageModel
{
    private readonly IProjectRepository _projectRepository;

    public Show(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public List<Entities.Project> Projects { get; set; }

    public void OnGet()
    {
        Projects = _projectRepository.GetAllProjects();
    }
}