using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using savemeapi.Data;
using savemeapi.Models;

namespace savemeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoadopcionsController : ControllerBase
    {
        private readonly SavemeContext _context;

        public EventoadopcionsController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Eventoadopcions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventoadopcion>>> GetEventoadopcions()
        {
          if (_context.Eventoadopcions == null)
          {
              return NotFound();
          }
            return await _context.Eventoadopcions.ToListAsync();
        }

        // GET: api/Eventoadopcions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventoadopcion>> GetEventoadopcion(int id)
        {
          if (_context.Eventoadopcions == null)
          {
              return NotFound();
          }
            var eventoadopcion = await _context.Eventoadopcions.FindAsync(id);

            if (eventoadopcion == null)
            {
                return NotFound();
            }

            return eventoadopcion;
        }

        // PUT: api/Eventoadopcions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoadopcion(int id, Eventoadopcion eventoadopcion)
        {
            if (id != eventoadopcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventoadopcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoadopcionExists(id))
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

        // POST: api/Eventoadopcions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eventoadopcion>> PostEventoadopcion(Eventoadopcion eventoadopcion)
        {
          if (_context.Eventoadopcions == null)
          {
              return Problem("Entity set 'SavemeContext.Eventoadopcions'  is null.");
          }
            _context.Eventoadopcions.Add(eventoadopcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoadopcion", new { id = eventoadopcion.Id }, eventoadopcion);
        }

        // DELETE: api/Eventoadopcions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoadopcion(int id)
        {
            if (_context.Eventoadopcions == null)
            {
                return NotFound();
            }
            var eventoadopcion = await _context.Eventoadopcions.FindAsync(id);
            if (eventoadopcion == null)
            {
                return NotFound();
            }

            _context.Eventoadopcions.Remove(eventoadopcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoadopcionExists(int id)
        {
            return (_context.Eventoadopcions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
