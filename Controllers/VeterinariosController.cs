﻿using System;
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
    public class VeterinariosController : ControllerBase
    {
        private readonly SavemeContext _context;

        public VeterinariosController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Veterinarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetVeterinarios()
        {
          if (_context.Veterinarios == null)
          {
              return NotFound();
          }
            return await _context.Veterinarios.ToListAsync();
        }

        // GET: api/Veterinarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetVeterinario(int id)
        {
          if (_context.Veterinarios == null)
          {
              return NotFound();
          }
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
            {
                return NotFound();
            }

            return veterinario;
        }

        // PUT: api/Veterinarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinario(int id, Veterinario veterinario)
        {
            if (id != veterinario.Id)
            {
                return BadRequest();
            }

            _context.Entry(veterinario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostVeterinario(Veterinario veterinario)
        {
          if (_context.Veterinarios == null)
          {
              return Problem("Entity set 'SavemeContext.Veterinarios'  is null.");
          }
            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeterinario", new { id = veterinario.Id }, veterinario);
        }

        // DELETE: api/Veterinarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinario(int id)
        {
            if (_context.Veterinarios == null)
            {
                return NotFound();
            }
            var veterinario = await _context.Veterinarios.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            _context.Veterinarios.Remove(veterinario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeterinarioExists(int id)
        {
            return (_context.Veterinarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
