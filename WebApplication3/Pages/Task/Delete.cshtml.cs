using Data.Repositories.Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementApp.Pages.Task;

public class Delete : PageModel
{
    private readonly ITaskRepository _taskRepository;

    public Delete(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [BindProperty] public TaskBase Task { get; set; }

    public IActionResult OnGet(int id)
    {
        Task = _taskRepository.GetTaskById(id);

        if (Task == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var task = _taskRepository.GetTaskById(id);

        if (task == null)
        {
            return NotFound();
        }
        
        _taskRepository.Delete(task);

        return RedirectToPage("/Index");
    }
}