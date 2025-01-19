using Data.Repositories.Contract;
using Entities;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagementApp.Pages.Task
{
    public class AddModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        public List<SelectListItem> Users { get; set; }
        private TaskBase? _task;

        public AddModel(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }
        [BindProperty] public AddTaskViewModel TaskVm { get; set; }

        public void OnGet()
        {
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

            switch (TaskVm.TaskType)
            {
                case "General":
                    _task = new GeneralTask
                    {
                        Name = TaskVm.Name,
                        Description = TaskVm.Description,
                        Priority = TaskVm.Priority,
                        Status = TaskVm.Status,
                        ReviewerId = TaskVm.ReviewerId,
                        IsReviewed = true
                    };
                    break;

                case "Feature":
                    _task = new FeatureTask
                    {
                        Name = TaskVm.Name,
                        Description = TaskVm.Description,
                        Priority = TaskVm.Priority,
                        Status = TaskVm.Status,
                        Estimate = TaskVm.Estimate
                    };
                    break;

                case "Bug":
                    _task = new BugTask
                    {
                        Name = TaskVm.Name,
                        Description = TaskVm.Description,
                        Status = TaskVm.Status,
                        Priority = TaskVm.Priority,
                        Severity = TaskVm.Severity
                    };
                    break;

                default:
                    return BadRequest("Invalid task type.");
            }

            _taskRepository.Add(_task);

            return RedirectToPage("/Task/Show");
        }
    }
}