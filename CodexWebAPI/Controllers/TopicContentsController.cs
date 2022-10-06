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
    public class TopicContentsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public TopicContentsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/TopicContents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicContent>>> GetTopicContent()
        {
            return  await _context.TopicContent.OrderBy(c => c.Topic.TopicIndex).ThenBy(n => n.TopicContentIndex).ToListAsync();
        }

        // GET: api/TopicContents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicContent>> GetTopicContent(Guid id)
        {
            var topicContent = await _context.TopicContent.FindAsync(id);

            if (topicContent == null)
            {
                return NotFound();
            }

            return topicContent;
        }
        [HttpGet("topic/{id}")]
        public async Task<ActionResult<IEnumerable<TopicContent>>> GetTopicContentinTopic(Guid id)
        {
            if (_context.TopicContent == null)
            {
                return NotFound();
            }
            var topicontent = await (from c in _context.TopicContent where c.TopicId == id select c).OrderBy(c => c.TopicContentIndex).ToListAsync();
            return topicontent;
        }


        // PUT: api/TopicContents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopicContent(Guid id, TopicContent topicContent)
        {
            if (id != topicContent.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(topicContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicContentExists(id))
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

        // POST: api/TopicContents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TopicContent>> PostTopicContent(TopicContent topicContent)
        {
            _context.TopicContent.Add(topicContent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopicContentExists(topicContent.ContentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopicContent", new { id = topicContent.ContentId }, topicContent);
        }

        // DELETE: api/TopicContents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicContent>> DeleteTopicContent(Guid id)
        {
            var topicContent = await _context.TopicContent.FindAsync(id);
            if (topicContent == null)
            {
                return NotFound();
            }

            _context.TopicContent.Remove(topicContent);
            await _context.SaveChangesAsync();

            return topicContent;
        }

        private bool TopicContentExists(Guid id)
        {
            return _context.TopicContent.Any(e => e.ContentId == id);
        }
    }
}
