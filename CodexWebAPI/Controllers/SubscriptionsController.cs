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
    public class SubscriptionsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public SubscriptionsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Subscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions()
        {
          if (_context.Subscriptions == null)
          {
              return NotFound();
          }
            return await _context.Subscriptions.ToListAsync();
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriptions>> GetSubscription(Guid id)
        {
          if (_context.Subscriptions == null)
          {
              return NotFound();
          }
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return subscription;
        }

        // PUT: api/Subscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(Guid id, Subscriptions subscription)
        {
            if (id != subscription.SubscriptionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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

        // POST: api/Subscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscriptions>> PostSubscription(Subscriptions subscription)
        {
          if (_context.Subscriptions == null)
          {
              return Problem("Entity set 'OC_DBContext.Subscriptions'  is null.");
          }
            _context.Subscriptions.Add(subscription);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriptionExists(subscription.SubscriptionTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubscription", new { id = subscription.SubscriptionTypeId }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            if (_context.Subscriptions == null)
            {
                return NotFound();
            }
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(Guid id)
        {
            return (_context.Subscriptions?.Any(e => e.SubscriptionTypeId == id)).GetValueOrDefault();
        }
    }
}
