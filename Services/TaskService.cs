using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

    }
}
