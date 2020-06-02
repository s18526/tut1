using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial8.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string TaskProjectName { get; set; }
        public int TaskTeamId { get; set; }

        public string CreatorLastName { get; set; }
        public string AssignedToLastName { get; set; }
        public string TaskType { get; set; }
    }
}
