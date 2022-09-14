using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDemo.Data;
using APIDemo.Models;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly APIDemoContext _context;

        public ToDoItemsController(APIDemoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItems>>> GetToDoItems()
        {
          if (_context.ToDoItems == null)
          {
              return NotFound();
          }
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItems>> GetToDoItems(long id)
        {
          if (_context.ToDoItems == null)
          {
              return NotFound();
          }
            var toDoItems = await _context.ToDoItems.FindAsync(id);

            if (toDoItems == null)
            {
                return NotFound();
            }

            return toDoItems;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItems(long id, ToDoItems toDoItems)
        {
            if (id != toDoItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemsExists(id))
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

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItems>> PostToDoItems(ToDoItems toDoItems)
        {
          if (_context.ToDoItems == null)
          {
              return Problem("Entity set 'APIDemoContext.ToDoItems'  is null.");
          }
            _context.ToDoItems.Add(toDoItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItems", new { id = toDoItems.Id }, toDoItems);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItems(long id)
        {
            if (_context.ToDoItems == null)
            {
                return NotFound();
            }
            var toDoItems = await _context.ToDoItems.FindAsync(id);
            if (toDoItems == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemsExists(long id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
