using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.DTOs.Responses;

namespace Tutorial8.Services
{
    public interface IDbService
    {
        public TaskRequestResponse requestDataById(string TaskId);
        public TaskRequestResponse returnAllTasks();

        bool isTaskExists(int TaskId);
    }
}
