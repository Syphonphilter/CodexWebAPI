using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodexWebAPI.Models;

namespace CodexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public OptionsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
          if (_context.Option == null)
          {
              return NotFound();
          }
            return await _context.Option.ToListAsync();
        }
        [HttpGet("question/{id}")]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions(Guid id)
        {
          if (_context.Option == null)
          {
              return NotFound();
          }
            return  await (from c in _context.Option where c.QuesitonId == id select c).OrderBy(c => c.OptionId).ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(Guid id)
        {
          if (_context.Option == null)
          {
              return NotFound();
          }
            var option = await _context.Option.FindAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(Guid id, Option option)
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
          if (_context.Option == null)
          {
              return Problem("Entity set 'OC_DBContext.Options'  is null.");
          }
            _context.Option.Add(option);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OptionExists(option.OptionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOption", new { id = option.OptionId }, option);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(Guid id)
        {
            if (_context.Option == null)
            {
                return NotFound();
            }
            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Option.Remove(option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionExists(Guid id)
        {
            return (_context.Option?.Any(e => e.OptionId == id)).GetValueOrDefault();
        }
    }
}
