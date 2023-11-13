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
    public class ReservaController : ControllerBase
    {
        private readonly AulaDbContext _context;

        public ReservaController(AulaDbContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
          if (_context.Reservas == null)
          {
              return NotFound();
          }
            return await _context.Reservas.ToListAsync();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
          if (_context.Reservas == null)
          {
              return NotFound();
          }
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.IdReseva)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaPostDto model)
        {
          if (_context.Reservas == null)
          {
              return Problem("Entity set 'AulaDbContext.Reservas'  is null.");
          }

            var reserva = new Reserva
            {   
                idUsuario = model.idUsuario,
                Usuario = await _context.Usuarios.FindAsync(model.idUsuario),
                idSala = model.idSala,
                Descricao = model.Descricao,
                Sala = await _context.Salas.FindAsync(model.idSala),
                DataFim = model.DataFim,
                DataInicio = model.DataInicio
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.IdReseva }, reserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            if (_context.Reservas == null)
            {
                return NotFound();
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return (_context.Reservas?.Any(e => e.IdReseva == id)).GetValueOrDefault();
        }
    }
}
