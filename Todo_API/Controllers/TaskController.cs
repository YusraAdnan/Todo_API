using Microsoft.AspNetCore.Mvc;
using Todo_API.Models;

namespace Todo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ToDoDbContext _dbContext; // use the EXACT name Scaffold-DbContext generated

        public TaskController(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _dbContext.TaskItems.ToList(); 
            return Ok(tasks);
        }
        
        // GET one specific task
        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST - create a new task
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem newTask)
        {
            newTask.Id = Guid.NewGuid();
            _dbContext.TaskItems.Add(newTask);
            _dbContext.SaveChanges();
            return Ok(newTask);
        }

        // DELETE - remove a task
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _dbContext.TaskItems.Remove(task);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
