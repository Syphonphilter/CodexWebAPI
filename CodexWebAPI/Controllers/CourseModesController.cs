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
    public class CourseModesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public CourseModesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/CourseModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModes>>> GetCourseModes()
        {
          if (_context.CourseModes == null)
          {
              return NotFound();
          }
            return await _context.CourseModes.ToListAsync();
        }

        // GET: api/CourseModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModes>> GetCourseMode(Guid id)
        {
          if (_context.CourseModes == null)
          {
              return NotFound();
          }
            var courseMode = await _context.CourseModes.FindAsync(id);

            if (courseMode == null)
            {
                return NotFound();
            }

            return courseMode;
        }

        // PUT: api/CourseModes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseMode(Guid id, CourseModes courseMode)
        {
            if (id != courseMode.CourseModeId)
            {
                return BadRequest();
            }

            _context.Entry(courseMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseModeExists(id))
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

        // POST: api/CourseModes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseModes>> PostCourseMode(CourseModes courseMode)
        {
          if (_context.CourseModes == null)
          {
              return Problem("Entity set 'OC_DBContext.CourseModes'  is null.");
          }
            _context.CourseModes.Add(courseMode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseModeExists(courseMode.CourseModeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseMode", new { id = courseMode.CourseModeId }, courseMode);
        }

        // DELETE: api/CourseModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseMode(Guid id)
        {
            if (_context.CourseModes == null)
            {
                return NotFound();
            }
            var courseMode = await _context.CourseModes.FindAsync(id);
            if (courseMode == null)
            {
                return NotFound();
            }

            _context.CourseModes.Remove(courseMode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseModeExists(Guid id)
        {
            return (_context.CourseModes?.Any(e => e.CourseModeId == id)).GetValueOrDefault();
        }
    }
}
