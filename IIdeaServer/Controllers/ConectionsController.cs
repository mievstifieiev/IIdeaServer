using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IIdeaServer.Model;

namespace IIdeaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConectionsController : ControllerBase
    {
        private readonly ConectionContext _context;

        public ConectionsController(ConectionContext context)
        {
            _context = context;
        }

        // GET: api/Conections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conection>>> GetConections()
        {
            return await _context.Conections.ToListAsync();
        }

        // GET: api/Conections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conection>> GetConection(long id)
        {
            var conection = await _context.Conections.FindAsync(id);

            if (conection == null)
            {
                return NotFound();
            }

            return conection;
        }

        // PUT: api/Conections/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConection(long id, Conection conection)
        {
            if (id != conection.Id)
            {
                return BadRequest();
            }

            _context.Entry(conection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConectionExists(id))
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

        // POST: api/Conections
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Conection>> PostConection(Conection conection)
        {
            _context.Conections.Add(conection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConection", new { id = conection.Id }, conection);
        }

        // DELETE: api/Conections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conection>> DeleteConection(long id)
        {
            var conection = await _context.Conections.FindAsync(id);
            if (conection == null)
            {
                return NotFound();
            }

            _context.Conections.Remove(conection);
            await _context.SaveChangesAsync();

            return conection;
        }

        private bool ConectionExists(long id)
        {
            return _context.Conections.Any(e => e.Id == id);
        }
    }
}
