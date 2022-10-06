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
    public class UserScoresController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public UserScoresController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/UserScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScores>>> GetUserScores()
        {
          if (_context.UserScores == null)
          {
              return NotFound();
          }
            return await _context.UserScores.ToListAsync();
        }

        // GET: api/UserScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserScores>> GetUserScore(int id)
        {
          if (_context.UserScores == null)
          {
              return NotFound();
          }
            var userScore = await _context.UserScores.FindAsync(id);

            if (userScore == null)
            {
                return NotFound();
            }

            return userScore;
        }

        // PUT: api/UserScores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserScore(int id, UserScores userScore)
        {
            if (id != userScore.Id)
            {
                return BadRequest();
            }

            _context.Entry(userScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserScoreExists(id))
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

        // POST: api/UserScores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserScores>> PostUserScore(UserScores userScore)
        {
          if (_context.UserScores == null)
          {
              return Problem("Entity set 'OC_DBContext.UserScores'  is null.");
          }
            _context.UserScores.Add(userScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserScore", new { id = userScore.Id }, userScore);
        }

        // DELETE: api/UserScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserScore(int id)
        {
            if (_context.UserScores == null)
            {
                return NotFound();
            }
            var userScore = await _context.UserScores.FindAsync(id);
            if (userScore == null)
            {
                return NotFound();
            }

            _context.UserScores.Remove(userScore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserScoreExists(int id)
        {
            return (_context.UserScores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
