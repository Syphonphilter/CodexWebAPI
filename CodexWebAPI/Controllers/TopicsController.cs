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
    public class TopicsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public TopicsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topics>>> GetTopics()
        {
          if (_context.Topics == null)
          {
              return NotFound();
          }
            return await _context.Topics.OrderBy(c => c.Module.ModuleIndex).ThenBy(n => n.TopicIndex).ToListAsync();
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topics>> GetTopic(Guid id)
        {
          if (_context.Topics == null)
          {
              return NotFound();
          }
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        [HttpGet("module/{id}")]
        public async Task<ActionResult<IEnumerable<Topics>>> GetTopicsInModule(Guid id)
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }
            var topics = await (from c in _context.Topics where c.ModuleId == id select c).OrderBy(c => c.TopicIndex).ToListAsync();
            return topics;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(Guid id, Topics topic)
        {
            if (id != topic.TopicId)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topics>> PostTopic(Topics topic)
        {
          if (_context.Topics == null)
          {
              return Problem("Entity set 'OC_DBContext.Topics'  is null.");
          }
            _context.Topics.Add(topic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopicExists(topic.TopicId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(Guid id)
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(Guid id)
        {
            return (_context.Topics?.Any(e => e.TopicId == id)).GetValueOrDefault();
        }
    }
}
