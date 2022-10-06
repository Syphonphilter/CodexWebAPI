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
    public class ModulesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public ModulesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModules()
        {
          if (_context.Modules == null)
          {
              return NotFound();
          }
            return await (from c in _context.Modules orderby c.ModuleIndex ascending select c).ToListAsync() ;
        }
        [HttpGet("course/{id}")]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModulesInCourse(Guid id)
        {
          if (_context.Modules == null)
          {
              return NotFound();
          }
            var modules = await (from c in _context.Modules where c.CourseId == id select c).OrderBy(c=> c.ModuleIndex).ToListAsync();
            return modules ;
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modules>> GetModule(Guid id)
        {
          if (_context.Modules == null)
          {
              return NotFound();
          }
            var @module = await _context.Modules.FindAsync(id);

            if (@module == null)
            {
                return NotFound();
            }

            return @module;
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(Guid id, Modules @module)
        {
            if (id != @module.ModuleId)
            {
                return BadRequest();
            }

            _context.Entry(@module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modules>> PostModule(Modules @module)
        {
          if (_context.Modules == null)
          {
              return Problem("Entity set 'OC_DBContext.Modules'  is null.");
          }
            _context.Modules.Add(@module);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuleExists(@module.ModuleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModule", new { id = @module.ModuleId }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            if (_context.Modules == null)
            {
                return NotFound();
            }
            var @module = await _context.Modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(@module);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleExists(Guid id)
        {
            return (_context.Modules?.Any(e => e.ModuleId == id)).GetValueOrDefault();
        }
    }
}
