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
    public class UserCoursesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public UserCoursesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/UserCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourse>>> GetUserCourses()
        {
          if (_context.UserCourse == null)
          {
              return NotFound();
          }
            return await _context.UserCourse.ToListAsync();
        }

        // GET: api/UserCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCourse>> GetUserCourse(Guid id)
        {
          if (_context.UserCourse == null)
          {
              return NotFound();
          }
            var userCourse = await _context.UserCourse.FindAsync(id);

            if (userCourse == null)
            {
                return NotFound();
            }

            return userCourse;
        }

        // PUT: api/UserCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCourse(Guid id, UserCourse userCourse)
        {
            if (id != userCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCourseExists(id))
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

        // POST: api/UserCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCourse>> PostUserCourse(UserCourse userCourse)
        {
          if (_context.UserCourse == null)
          {
              return Problem("Entity set 'OC_DBContext.UserCourses'  is null.");
          }
            _context.UserCourse.Add(userCourse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCourseExists(userCourse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCourse", new { id = userCourse.Id }, userCourse);
        }

        // DELETE: api/UserCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCourse(Guid id)
        {
            if (_context.UserCourse == null)
            {
                return NotFound();
            }
            var userCourse = await _context.UserCourse.FindAsync(id);
            if (userCourse == null)
            {
                return NotFound();
            }

            _context.UserCourse.Remove(userCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCourseExists(Guid id)
        {
            return (_context.UserCourse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
