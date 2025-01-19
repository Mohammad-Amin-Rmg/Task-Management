using Data.Repositories.Contract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TaskRepository(ApplicationDbContext context) : Repository<TaskBase>(context), ITaskRepository
    {
        private readonly ApplicationDbContext _context = context;

        public TaskBase GetTaskById(int id)
        {
            return _context.TaskBases.Find(id) ?? throw new KeyNotFoundException($"Task with ID {id} was not found.");
        }

        public List<TaskBase> GetAllTasks()
        {
            return _context.TaskBases.ToList();
        }

        public List<TaskBase> GetTasksWithUsers()
        {
            return _context.TaskBases
                .Include(t => t.AssignedUser!)
                .ToList();
        }
        public TaskBase GetTaskWithUserById(int id)
        {
            return _context.TaskBases
                .Include(t => t.AssignedUser)
                .FirstOrDefault(t => t.Id == id)!;
        }

        public void AssignUserToTask(int taskId, int userId)
        {
            var task = GetTaskById(taskId);
            task.AssignedUserId = userId;
            
            _context.SaveChangesAsync();
        }
    }
}