using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoTasksController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetToDoTasks()
        {
            return await _context.ToDoTasks.ToListAsync();
        }

        // GET: api/ToDoTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoTask>> GetToDoTask(int id)
        {
            var toDoTask = await _context.ToDoTasks.FindAsync(id);

            if (toDoTask == null)
            {
                return NotFound();
            }

            return toDoTask;
        }

        // GET: api/ToDoTasks/5
        // GET: api/ToDoTasks/ByDate/{date}
        [HttpGet("ByDate/{date}")]
        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetToDoTask(string date)
        {
            var selectedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            selectedDate = selectedDate.AddDays(1);
            return await _context.ToDoTasks.Where(t => t.TaskDate.Date == selectedDate.Date).ToListAsync();
        }



        // PUT: api/ToDoTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoTask(int id, ToDoTask toDoTask)
        {
            if (id != toDoTask.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(toDoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ToDoTask>> PostToDoTask(ToDoTask toDoTask)
        {
            _context.ToDoTasks.Add(toDoTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoTask", new { id = toDoTask.TaskId }, toDoTask);
        }

        // DELETE: api/ToDoTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoTask>> DeleteToDoTask(int id)
        {
            var toDoTask = await _context.ToDoTasks.FindAsync(id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            _context.ToDoTasks.Remove(toDoTask);
            await _context.SaveChangesAsync();

            return toDoTask;
        }

        private bool ToDoTaskExists(int id)
        {
            return _context.ToDoTasks.Any(e => e.TaskId == id);
        }
    }
}
