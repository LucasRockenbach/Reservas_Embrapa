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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            if (_context.Reservas == null)
            {
                return NotFound();
            }

            // Inclua as informações da sala e do usuário associadas a cada reserva
            var reservas = await _context.Reservas
                .Include(r => r.Sala)
                .Include(r => r.Usuario)
                .ToListAsync();

            return reservas;
        }



        // GET: api/Reserva/5
        [HttpGet("{id}/")]
        public async Task<ActionResult<Reserva>> GetReservaID(int id)
        {
            if (_context.Reservas == null)
            {
                return NotFound();
            }

            // Inclua as informações da sala e do usuário associadas a esta reserva específica
            var reserva = await _context.Reservas
                .Include(r => r.Sala)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.IdReseva == id);

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
                return Problem("Entity set 'AulaDbContext.Reservas' is null.");
            }

            // Procurar o usuário pelo nome
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == model.nomeUsuario);
            if (usuario == null)
            {
                // Se o usuário não existir, você pode criar um novo usuário ou retornar um erro, dependendo dos requisitos do seu aplicativo.
                // Aqui, estou retornando um erro NotFound.
                return NotFound($"Usuário com nome {model.nomeUsuario} não encontrado.");
            }

            // Procurar a sala pelo nome
            var sala = await _context.Salas.FirstOrDefaultAsync(s => s.Nome == model.nomeSala);
            if (sala == null)
            {
                // Se a sala não existir, você pode criar uma nova sala ou retornar um erro, dependendo dos requisitos do seu aplicativo.
                // Aqui, estou retornando um erro NotFound.
                return NotFound($"Sala com nome {model.nomeSala} não encontrada.");
            }

            var reserva = new Reserva
            {
                Usuario = usuario,
                Sala = sala,
                Descricao = model.Descricao,
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
