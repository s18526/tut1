using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial8.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tutorial8.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        IDbService dbService;

        public TasksController(IDbService service)
        {
            this.dbService = service;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult getTasks(string id)
        {
            return Ok(dbService.requestDataById(id));
        }
    }
}
