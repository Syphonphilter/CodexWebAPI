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
    public class CoursePricesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public CoursePricesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/CoursePrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoursePrices>>> GetCoursePrices()
        {
          if (_context.CoursePrices == null)
          {
              return NotFound();
          }
            return await _context.CoursePrices.ToListAsync();
        }

        // GET: api/CoursePrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoursePrices>> GetCoursePrice(Guid id)
        {
          if (_context.CoursePrices == null)
          {
              return NotFound();
          }
            var coursePrice = await _context.CoursePrices.FindAsync(id);

            if (coursePrice == null)
            {
                return NotFound();
            }

            return coursePrice;
        }

        // PUT: api/CoursePrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursePrice(Guid id, CoursePrices coursePrice)
        {
            if (id != coursePrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(coursePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursePriceExists(id))
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

        // POST: api/CoursePrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoursePrices>> PostCoursePrice(CoursePrices coursePrice)
        {
          if (_context.CoursePrices == null)
          {
              return Problem("Entity set 'OC_DBContext.CoursePrices'  is null.");
          }
            _context.CoursePrices.Add(coursePrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoursePriceExists(coursePrice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoursePrice", new { id = coursePrice.Id }, coursePrice);
        }

        // DELETE: api/CoursePrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursePrice(Guid id)
        {
            if (_context.CoursePrices == null)
            {
                return NotFound();
            }
            var coursePrice = await _context.CoursePrices.FindAsync(id);
            if (coursePrice == null)
            {
                return NotFound();
            }

            _context.CoursePrices.Remove(coursePrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursePriceExists(Guid id)
        {
            return (_context.CoursePrices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
