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
    public class QuestionOptionsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public QuestionOptionsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/QuestionOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionOption>>> GetQuestionOptions()
        {
          if (_context.QuestionOption == null)
          {
              return NotFound();
          }
            return await _context.QuestionOption.ToListAsync();
        }

        // GET: api/QuestionOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionOption>> GetQuestionOption(Guid id)
        {
          if (_context.QuestionOption == null)
          {
              return NotFound();
          }
            var questionOption = await _context.QuestionOption.FindAsync(id);

            if (questionOption == null)
            {
                return NotFound();
            }

            return questionOption;
        }
        [HttpGet("question/{id}")]
        public async Task<ActionResult<QuestionOption>> GetQuestionOptionbyQuestion(Guid id)
        {
            if (_context.QuestionOption == null)
            {
                return NotFound();
            }
            var questionOption = await (from c in _context.QuestionOption where c.QuestionId == id select c).FirstOrDefaultAsync();

            if (questionOption == null)
            {
                return NotFound();
            }

            return questionOption;
        }


        // PUT: api/QuestionOptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionOption(Guid id, QuestionOption questionOption)
        {
            if (id != questionOption.QuesitonOptionId)
            {
                return BadRequest();
            }

            _context.Entry(questionOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionOptionExists(id))
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

        // POST: api/QuestionOptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionOption>> PostQuestionOption(QuestionOption questionOption)
        {
          if (_context.QuestionOption == null)
          {
              return Problem("Entity set 'OC_DBContext.QuestionOptions'  is null.");
          }
            _context.QuestionOption.Add(questionOption);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionOptionExists(questionOption.QuesitonOptionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionOption", new { id = questionOption.QuesitonOptionId }, questionOption);
        }

        // DELETE: api/QuestionOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionOption(Guid id)
        {
            if (_context.QuestionOption == null)
            {
                return NotFound();
            }
            var questionOption = await _context.QuestionOption.FindAsync(id);
            if (questionOption == null)
            {
                return NotFound();
            }

            _context.QuestionOption.Remove(questionOption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionOptionExists(Guid id)
        {
            return (_context.QuestionOption?.Any(e => e.QuesitonOptionId == id)).GetValueOrDefault();
        }
    }
}
