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
    public class ModuleCategoriesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public ModuleCategoriesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/ModuleCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleCategories>>> GetModuleCategories()
        {
          if (_context.ModuleCategories == null)
          {
              return NotFound();
          }
            return await _context.ModuleCategories.ToListAsync();
        }

        // GET: api/ModuleCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleCategories>> GetModuleCategory(Guid id)
        {
          if (_context.ModuleCategories == null)
          {
              return NotFound();
          }
            var moduleCategory = await _context.ModuleCategories.FindAsync(id);

            if (moduleCategory == null)
            {
                return NotFound();
            }

            return moduleCategory;
        }

        // PUT: api/ModuleCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleCategory(Guid id, ModuleCategories moduleCategory)
        {
            if (id != moduleCategory.ModuleCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(moduleCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleCategoryExists(id))
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

        // POST: api/ModuleCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModuleCategories>> PostModuleCategory(ModuleCategories moduleCategory)
        {
          if (_context.ModuleCategories == null)
          {
              return Problem("Entity set 'OC_DBContext.ModuleCategories'  is null.");
          }
            _context.ModuleCategories.Add(moduleCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuleCategoryExists(moduleCategory.ModuleCategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModuleCategory", new { id = moduleCategory.ModuleCategoryId }, moduleCategory);
        }

        // DELETE: api/ModuleCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuleCategory(Guid id)
        {
            if (_context.ModuleCategories == null)
            {
                return NotFound();
            }
            var moduleCategory = await _context.ModuleCategories.FindAsync(id);
            if (moduleCategory == null)
            {
                return NotFound();
            }

            _context.ModuleCategories.Remove(moduleCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleCategoryExists(Guid id)
        {
            return (_context.ModuleCategories?.Any(e => e.ModuleCategoryId == id)).GetValueOrDefault();
        }
    }
}
