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
    public class UserAnswersController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public UserAnswersController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/UserAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAnswers>>> GetUserAnswers()
        {
          if (_context.UserAnswers == null)
          {
              return NotFound();
          }
            return await _context.UserAnswers.ToListAsync();
        }

        // GET: api/UserAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAnswers>> GetUserAnswer(Guid id)
        {
          if (_context.UserAnswers == null)
          {
              return NotFound();
          }
            var userAnswer = await _context.UserAnswers.FindAsync(id);

            if (userAnswer == null)
            {
                return NotFound();
            }

            return userAnswer;
        }

        // PUT: api/UserAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAnswer(Guid id, UserAnswers userAnswer)
        {
            if (id != userAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswerExists(id))
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

        // POST: api/UserAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAnswers>> PostUserAnswer(UserAnswers userAnswer)
        {
          if (_context.UserAnswers == null)
          {
              return Problem("Entity set 'OC_DBContext.UserAnswers'  is null.");
          }
            _context.UserAnswers.Add(userAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAnswerExists(userAnswer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAnswer", new { id = userAnswer.Id }, userAnswer);
        }

        // DELETE: api/UserAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAnswer(Guid id)
        {
            if (_context.UserAnswers == null)
            {
                return NotFound();
            }
            var userAnswer = await _context.UserAnswers.FindAsync(id);
            if (userAnswer == null)
            {
                return NotFound();
            }

            _context.UserAnswers.Remove(userAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAnswerExists(Guid id)
        {
            return (_context.UserAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
