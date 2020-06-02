using System;
using System.Collections.Generic;
using System.Linq;
using Tutorial8.Models;

namespace Tutorial8.DTOs.Responses
{
    public class TaskRequestResponse
    {
        public List<Task> taskList;

        public TaskRequestResponse()
        {
            taskList = new List<Task>();
        }
    }
}
