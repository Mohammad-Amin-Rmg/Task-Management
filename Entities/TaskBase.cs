using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskBase
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public User? AssignedUser { get; set; }
        public int? AssignedUserId { get; set; }

    }
}
