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
    public class MediaController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public MediaController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia()
        {
          if (_context.Media == null)
          {
              return NotFound();
          }
            return await _context.Media.ToListAsync();
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Media>> GetMedia(Guid id)
        {
          if (_context.Media == null)
          {
              return NotFound();
          }
            var medium = await _context.Media.FindAsync(id);

            if (medium == null)
            {
                return NotFound();
            }

            return medium;
        }

        // PUT: api/Media/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(Guid id, Media medium)
        {
            if (id != medium.MediaId)
            {
                return BadRequest();
            }

            _context.Entry(medium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST: api/Media
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Media>> PostMedia(Media medium)
        {
          if (_context.Media == null)
          {
              return Problem("Entity set 'OC_DBContext.Media'  is null.");
          }
            _context.Media.Add(medium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediaExists(medium.MediaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedia", new { id = medium.MediaId }, medium);
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(Guid id)
        {
            if (_context.Media == null)
            {
                return NotFound();
            }
            var medium = await _context.Media.FindAsync(id);
            if (medium == null)
            {
                return NotFound();
            }

            _context.Media.Remove(medium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaExists(Guid id)
        {
            return (_context.Media?.Any(e => e.MediaId == id)).GetValueOrDefault();
        }
    }
}
