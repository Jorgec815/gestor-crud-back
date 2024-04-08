using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestor_crud_back.Models;

namespace gestor_crud_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcesionariosController : ControllerBase
    {
        private readonly VentasVehiculosContext _context;

        public ConcesionariosController(VentasVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Concesionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concesionario>>> GetConcesionarios()
        {
            return await _context.Concesionarios.ToListAsync();
        }

        // GET: api/Concesionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concesionario>> GetConcesionario(int id)
        {
            var concesionario = await _context.Concesionarios.FindAsync(id);

            if (concesionario == null)
            {
                return NotFound();
            }

            return concesionario;
        }

        // PUT: api/Concesionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcesionario(int id, Concesionario concesionario)
        {
            if (id != concesionario.ConcesionarioId)
            {
                return BadRequest();
            }

            _context.Entry(concesionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcesionarioExists(id))
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

        // POST: api/Concesionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concesionario>> PostConcesionario(Concesionario concesionario)
        {
            _context.Concesionarios.Add(concesionario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConcesionarioExists(concesionario.ConcesionarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConcesionario", new { id = concesionario.ConcesionarioId }, concesionario);
        }

        // DELETE: api/Concesionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcesionario(int id)
        {
            var concesionario = await _context.Concesionarios.FindAsync(id);
            if (concesionario == null)
            {
                return NotFound();
            }

            _context.Concesionarios.Remove(concesionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcesionarioExists(int id)
        {
            return _context.Concesionarios.Any(e => e.ConcesionarioId == id);
        }
    }
}
