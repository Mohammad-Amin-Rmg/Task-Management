using Data.Repositories.Contract;
using Entities.Enums;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskManagementApp.Pages.Task
{
    public class EditModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        public EditModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public SelectList Priority { get; set; }
        public SelectList Status { get; set; }
        public SelectList Severity { get; set; }
        [BindProperty] public EditTaskViewModel TaskVm { get; set; }

        public IActionResult OnGet(int id)
        {
            var taskEnity = _taskRepository.GetTaskById(id);

            TaskVm = new EditTaskViewModel()
            {
                Id = taskEnity.Id,
                Name = taskEnity.Name,
                Description = taskEnity.Description!,
                Priority = taskEnity.Priority
            };

            if (taskEnity == null)
            {
                return NotFound();
            }

            Priority = new SelectList(Enum.GetValues(typeof(Priority)));
            Status = new SelectList(Enum.GetValues(typeof(Status)));
            Severity = new SelectList(Enum.GetValues(typeof(BugSeverity)));

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var taskEntity = _taskRepository.GetTaskById(TaskVm.Id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            taskEntity.Name = TaskVm.Name;
            taskEntity.Description = TaskVm.Description;
            taskEntity.Priority = TaskVm.Priority;
            taskEntity.Deadline = TaskVm.Deadline;
            taskEntity.Status = TaskVm.Status;


            _taskRepository.Update(taskEntity);

            return RedirectToPage("/Task/Show");
        }
    }
}
