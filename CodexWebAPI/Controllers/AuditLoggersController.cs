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
    public class AuditLoggersController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public AuditLoggersController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/AuditLoggers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLogger>>> GetAuditLoggers()
        {
          if (_context.AuditLogger == null)
          {
              return NotFound();
          }
            return await _context.AuditLogger.ToListAsync();
        }

        // GET: api/AuditLoggers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLogger>> GetAuditLogger(Guid id)
        {
          if (_context.AuditLogger == null)
          {
              return NotFound();
          }
            var auditLogger = await _context.AuditLogger.FindAsync(id);

            if (auditLogger == null)
            {
                return NotFound();
            }

            return auditLogger;
        }

        // PUT: api/AuditLoggers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditLogger(Guid id, AuditLogger auditLogger)
        {
            if (id != auditLogger.Id)
            {
                return BadRequest();
            }

            _context.Entry(auditLogger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditLoggerExists(id))
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

        // POST: api/AuditLoggers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuditLogger>> PostAuditLogger(AuditLogger auditLogger)
        {
          if (_context.AuditLogger == null)
          {
              return Problem("Entity set 'OC_DBContext.AuditLoggers'  is null.");
          }
            _context.AuditLogger.Add(auditLogger);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuditLoggerExists(auditLogger.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuditLogger", new { id = auditLogger.Id }, auditLogger);
        }

        // DELETE: api/AuditLoggers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditLogger(Guid id)
        {
            if (_context.AuditLogger == null)
            {
                return NotFound();
            }
            var auditLogger = await _context.AuditLogger.FindAsync(id);
            if (auditLogger == null)
            {
                return NotFound();
            }

            _context.AuditLogger.Remove(auditLogger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditLoggerExists(Guid id)
        {
            return (_context.AuditLogger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
