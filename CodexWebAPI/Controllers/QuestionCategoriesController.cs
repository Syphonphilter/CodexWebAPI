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
    public class QuestionCategoriesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public QuestionCategoriesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/QuestionCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionCategory>>> GetQuestionCategories()
        {
          if (_context.QuestionCategory == null)
          {
              return NotFound();
          }
            return await _context.QuestionCategory.ToListAsync();
        }

        // GET: api/QuestionCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionCategory>> GetQuestionCategory(Guid id)
        {
          if (_context.QuestionCategory == null)
          {
              return NotFound();
          }
            var questionCategory = await _context.QuestionCategory.FindAsync(id);

            if (questionCategory == null)
            {
                return NotFound();
            }

            return questionCategory;
        }

        // PUT: api/QuestionCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionCategory(Guid id, QuestionCategory questionCategory)
        {
            if (id != questionCategory.QuestionCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(questionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionCategoryExists(id))
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

        // POST: api/QuestionCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionCategory>> PostQuestionCategory(QuestionCategory questionCategory)
        {
          if (_context.QuestionCategory == null)
          {
              return Problem("Entity set 'OC_DBContext.QuestionCategories'  is null.");
          }
            _context.QuestionCategory.Add(questionCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionCategoryExists(questionCategory.QuestionCategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionCategory", new { id = questionCategory.QuestionCategoryId }, questionCategory);
        }

        // DELETE: api/QuestionCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionCategory(Guid id)
        {
            if (_context.QuestionCategory == null)
            {
                return NotFound();
            }
            var questionCategory = await _context.QuestionCategory.FindAsync(id);
            if (questionCategory == null)
            {
                return NotFound();
            }

            _context.QuestionCategory.Remove(questionCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionCategoryExists(Guid id)
        {
            return (_context.QuestionCategory?.Any(e => e.QuestionCategoryId == id)).GetValueOrDefault();
        }
    }
}
