using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public Roles Role { get; set; }
        public TaskBase? Task { get; set; }
        //public int TaskId { get; set; }

    }
}
