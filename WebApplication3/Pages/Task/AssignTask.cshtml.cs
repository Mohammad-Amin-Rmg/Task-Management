using Data;
using Data.Repositories.Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagementApp.Pages.Task;

public class AssignTask : PageModel
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public AssignTask(IUserRepository userRepository, ITaskRepository taskRepository)
    {
        _userRepository = userRepository;
        _taskRepository = taskRepository;
    }

    [BindProperty] public int TaskId { get; set; }
    [BindProperty] public int? SelectedUserId { get; set; }

    public TaskBase Task { get; set; }
    public List<SelectListItem> Users { get; set; }

    public void OnGet(int id)
    {
        TaskId = id;
        Task = _taskRepository.GetTaskWithUserById(id);

        Users = _userRepository.GetAllUsers().Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.Name} ({u.Role})"
            })
            .ToList();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var task = _taskRepository.GetTaskWithUserById(TaskId);

        if (task == null)
        {
            return NotFound();
        }

        _taskRepository.AssignUserToTask(task.Id, SelectedUserId!.Value);

        return RedirectToPage("Show");
    }
}