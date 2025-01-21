using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class ShowSearchResultViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string AssignedUserName { get; set; }
        public Status Status { get; set; }
    }
}
