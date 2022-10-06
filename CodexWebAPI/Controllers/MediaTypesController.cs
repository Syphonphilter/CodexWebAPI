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
    public class MediaTypesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public MediaTypesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/MediaTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaTypes>>> GetMediaTypes()
        {
          if (_context.MediaTypes == null)
          {
              return NotFound();
          }
            return await _context.MediaTypes.ToListAsync();
        }

        // GET: api/MediaTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaTypes>> GetMediaType(Guid id)
        {
          if (_context.MediaTypes == null)
          {
              return NotFound();
          }
            var mediaType = await _context.MediaTypes.FindAsync(id);

            if (mediaType == null)
            {
                return NotFound();
            }

            return mediaType;
        }

        // PUT: api/MediaTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaType(Guid id, MediaTypes mediaType)
        {
            if (id != mediaType.MediaTypeId)
            {
                return BadRequest();
            }

            _context.Entry(mediaType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaTypeExists(id))
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

        // POST: api/MediaTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaTypes>> PostMediaType(MediaTypes mediaType)
        {
          if (_context.MediaTypes == null)
          {
              return Problem("Entity set 'OC_DBContext.MediaTypes'  is null.");
          }
            _context.MediaTypes.Add(mediaType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediaTypeExists(mediaType.MediaTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediaType", new { id = mediaType.MediaTypeId }, mediaType);
        }

        // DELETE: api/MediaTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaType(Guid id)
        {
            if (_context.MediaTypes == null)
            {
                return NotFound();
            }
            var mediaType = await _context.MediaTypes.FindAsync(id);
            if (mediaType == null)
            {
                return NotFound();
            }

            _context.MediaTypes.Remove(mediaType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaTypeExists(Guid id)
        {
            return (_context.MediaTypes?.Any(e => e.MediaTypeId == id)).GetValueOrDefault();
        }
    }
}
