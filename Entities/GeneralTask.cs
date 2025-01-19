using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GeneralTask : TaskBase
    {
        public int? ReviewerId { get; set; }
        public bool IsReviewed { get; set; }
    }
}
