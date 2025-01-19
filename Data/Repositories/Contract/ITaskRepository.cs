using Entities;

namespace Data.Repositories.Contract
{
    public interface ITaskRepository : IRepository<TaskBase>
    {
        List<TaskBase> GetAllTasks();
        TaskBase GetTaskById(int id);
        void AssignUserToTask(int taskId, int userId);
        TaskBase GetTaskWithUserById(int id);
        List<TaskBase> GetTasksWithUsers();

    }
}