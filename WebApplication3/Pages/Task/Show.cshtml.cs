using Data.Repositories.Contract;
using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskManagementApp.Pages.Task
{
    public class ShowModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;

        public ShowModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskBase>? Tasks { get; set; }

        public void OnGet()
        {
            Tasks = _taskRepository.GetTasksWithUsers();
        }
    }
}
