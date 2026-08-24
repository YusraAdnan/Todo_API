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

        //This will get all the tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _dbContext.TaskItems.ToList(); 
            return Ok(tasks);
        }


        // GET one specific task
        //api/task/5 
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























        //    // POST - create a new task
        //    /*[FromBody] explicitly says that the content will be sent from the request body 
        //     The request body will be an object of the TaskItem class */
        //    [HttpPost]
        //    public IActionResult CreateTask([FromBody] TaskItem newTask)
        //    {
        //        newTask.Id = Guid.NewGuid();
        //        _dbContext.TaskItems.Add(newTask);
        //        _dbContext.SaveChanges();
        //        return Ok(newTask); //for now lets use Ok() which means success but you can also be explicit
        //    }

        //    //PUT - update an existing task, needs an Id extension in the URL 
        //    [HttpPut("{id}")]
        //    public IActionResult UpdateTask(Guid id, [FromBody] bool isComplete)
        //    {
        //        var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);
        //        if (task == null)
        //        {
        //            return NotFound();
        //        }

        //        task.IsComplete = isComplete;
        //        _dbContext.SaveChanges();

        //        return Ok(task);
        //    }

        //    // DELETE - remove a task
        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteTask(Guid id)
        //    {
        //        var task = _dbContext.TaskItems.FirstOrDefault(t => t.Id == id);
        //        if (task == null)
        //        {
        //            return NotFound();
        //        }

        //        _dbContext.TaskItems.Remove(task);
        //        _dbContext.SaveChanges();

        //        return NoContent();
        //    }
        }
    }
