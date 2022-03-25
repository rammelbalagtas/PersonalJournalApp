using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.Models.Models;
using PersonalJournal.WebAPI.Data;

namespace PersonalJournal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsectionsController : ControllerBase
    {
        private readonly PersonalJournalDBContext _context;

        public SubsectionsController(PersonalJournalDBContext context)
        {
            _context = context;
        }

        // GET: api/Subsections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subsection>>> GetSubsections()
        {
            return await _context.Subsections.ToListAsync();
        }

        // GET: api/Subsections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subsection>> GetSubsection(int id)
        {
            var subsection = await _context.Subsections.FindAsync(id);

            if (subsection == null)
            {
                return NotFound();
            }

            return subsection;
        }

        // PUT: api/Subsections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubsection(int id, Subsection subsection)
        {
            if (id != subsection.Id)
            {
                return BadRequest();
            }

            _context.Entry(subsection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubsectionExists(id))
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

        // POST: api/Subsections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subsection>> PostSubsection(Subsection subsection)
        {
            _context.Subsections.Add(subsection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubsection", new { id = subsection.Id }, subsection);
        }

        // DELETE: api/Subsections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubsection(int id)
        {
            var subsection = await _context.Subsections.FindAsync(id);
            if (subsection == null)
            {
                return NotFound();
            }

            _context.Subsections.Remove(subsection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubsectionExists(int id)
        {
            return _context.Subsections.Any(e => e.Id == id);
        }
    }
}
