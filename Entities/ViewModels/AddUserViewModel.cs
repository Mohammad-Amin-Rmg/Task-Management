using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class AddUserViewModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Roles Role { get; set; }
    }
}