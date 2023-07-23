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
    public class ParticipanteeventoesController : ControllerBase
    {
        private readonly SavemeContext _context;

        public ParticipanteeventoesController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Participanteeventoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participanteevento>>> GetParticipanteeventos()
        {
          if (_context.Participanteeventos == null)
          {
              return NotFound();
          }
            return await _context.Participanteeventos.ToListAsync();
        }

        // GET: api/Participanteeventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participanteevento>> GetParticipanteevento(int id)
        {
          if (_context.Participanteeventos == null)
          {
              return NotFound();
          }
            var participanteevento = await _context.Participanteeventos.FindAsync(id);

            if (participanteevento == null)
            {
                return NotFound();
            }

            return participanteevento;
        }

        // PUT: api/Participanteeventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipanteevento(int id, Participanteevento participanteevento)
        {
            if (id != participanteevento.Id)
            {
                return BadRequest();
            }

            _context.Entry(participanteevento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteeventoExists(id))
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

        // POST: api/Participanteeventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participanteevento>> PostParticipanteevento(Participanteevento participanteevento)
        {
          if (_context.Participanteeventos == null)
          {
              return Problem("Entity set 'SavemeContext.Participanteeventos'  is null.");
          }
            _context.Participanteeventos.Add(participanteevento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipanteevento", new { id = participanteevento.Id }, participanteevento);
        }

        // DELETE: api/Participanteeventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipanteevento(int id)
        {
            if (_context.Participanteeventos == null)
            {
                return NotFound();
            }
            var participanteevento = await _context.Participanteeventos.FindAsync(id);
            if (participanteevento == null)
            {
                return NotFound();
            }

            _context.Participanteeventos.Remove(participanteevento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipanteeventoExists(int id)
        {
            return (_context.Participanteeventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
