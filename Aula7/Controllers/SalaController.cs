﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aula7.Data;
using Aula7.Models;

namespace Aula7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly AulaDbContext _context;

        public SalaController(AulaDbContext context)
        {
            _context = context;
        }

        // GET: api/Sala
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas()
        {
          if (_context.Salas == null)
          {
              return NotFound();
          }
            return await _context.Salas.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasDaSala(int id)
        {
            var sala = await _context.Salas
                .Include(s => s.Reserva)
                    .ThenInclude(r => r.Usuario) // Inclua as informações do usuário
                .FirstOrDefaultAsync(s => s.idSala == id);

            if (sala == null)
            {
                return NotFound();
            }

            return sala.Reserva.ToList();
        }

        // PUT: api/Sala/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala sala)
        {
            if (id != sala.idSala)
            {
                return BadRequest();
            }

            _context.Entry(sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Sala
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
          if (_context.Salas == null)
          {
              return Problem("Entity set 'AulaDbContext.Salas'  is null.");
          }
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSala", new { id = sala.idSala }, sala);
        }

        // DELETE: api/Sala/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            if (_context.Salas == null)
            {
                return NotFound();
            }
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaExists(int id)
        {
            return (_context.Salas?.Any(e => e.idSala == id)).GetValueOrDefault();
        }
    }
}
