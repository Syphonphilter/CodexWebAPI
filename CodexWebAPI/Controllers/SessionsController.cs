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
    public class SessionsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public SessionsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sessions>>> GetSessions()
        {
          if (_context.Sessions == null)
          {
              return NotFound();
          }
            return await _context.Sessions.ToListAsync();
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sessions>> GetSession(Guid id)
        {
          if (_context.Sessions == null)
          {
              return NotFound();
          }
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return session;
        }
        [HttpGet("getsessioninfo/{userid}/{courseid}")]
        public async Task<ActionResult<Sessions>> GetSessionInfo(Guid userid, Guid courseid)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
        
            var user =  (from c in _context.Users where c.UserId ==userid select c ).FirstOrDefault();
            var usersession =  (from c in _context.Sessions where c.UserId == userid select c ).FirstOrDefault();
          
            var session = new Sessions();

            if (usersession == null)
            {
                return NotFound();
            }
            else
            {

                var gettopic = (from c in _context.Topics where c.TopicId == usersession.CurrentTopicId select c).FirstOrDefault();
                var getmodule = (from c in _context.Modules where c.ModuleId == gettopic.ModuleId select c).FirstOrDefault();
                var getcourse = (from c in _context.Course where c.CourseId == getmodule.CourseId select c).FirstOrDefault();
                if (getmodule.CourseId == courseid)
                {
                  session = usersession;
                }
            }

            return session;
        }

        // PUT: api/Sessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(Guid id, Sessions session)
        {
            if (id != session.SessionId)
            {
                return BadRequest();
            }

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sessions>> PostSession(Sessions session)
        {
          if (_context.Sessions == null)
          {
              return Problem("Entity set 'OC_DBContext.Sessions'  is null.");
          }
            _context.Sessions.Add(session);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SessionExists(session.SessionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSession", new { id = session.SessionId }, session);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            if (_context.Sessions == null)
            {
                return NotFound();
            }
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionExists(Guid id)
        {
            return (_context.Sessions?.Any(e => e.SessionId == id)).GetValueOrDefault();
        }
    }
}
