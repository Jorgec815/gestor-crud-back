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
    public class TransaccionesController : ControllerBase
    {
        private readonly VentasVehiculosContext _context;

        public TransaccionesController(VentasVehiculosContext context)
        {
            _context = context;
        }

        // GET: api/Transacciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacciones>>> GetTransacciones()
        {
            try
            {
                return await _context.Transacciones.Include(c => c.Cliente).Include(c => c.Concesionario).Include(c => c.Vehiculo).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/Transacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacciones>> GetTransaccione(int id)
        {
            Transacciones transaccione = await _context.Transacciones.FindAsync(id);

            if (transaccione == null)
            {
                return NotFound();
            }

            try
            {
                transaccione = await _context.Transacciones.Include(c => c.Cliente).Include(c => c.Concesionario).Include(c => c.Vehiculo).FirstAsync(c => c.TransaccionId == id);
                return transaccione;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Transacciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccione(int id, Transacciones transaccione)
        {
            if (id != transaccione.TransaccionId)
            {
                return BadRequest();
            }

            _context.Entry(transaccione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccioneExists(id))
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

        // POST: api/Transacciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transacciones>> PostTransaccione(Transacciones transaccione)
        {
            _context.Transacciones.Add(transaccione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransaccioneExists(transaccione.TransaccionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransaccione", new { id = transaccione.TransaccionId }, transaccione);
        }

        // DELETE: api/Transacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccione(int id)
        {
            var transaccione = await _context.Transacciones.FindAsync(id);
            if (transaccione == null)
            {
                return NotFound();
            }

            _context.Transacciones.Remove(transaccione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransaccioneExists(int id)
        {
            return _context.Transacciones.Any(e => e.TransaccionId == id);
        }
    }
}
