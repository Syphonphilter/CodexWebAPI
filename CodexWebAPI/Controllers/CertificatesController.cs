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
    public class CertificatesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public CertificatesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Certificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificates>>> GetCertificates()
        {
          if (_context.Certificates == null)
          {
              return NotFound();
          }
            return await _context.Certificates.ToListAsync();
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certificates>> GetCertificate(Guid id)
        {
          if (_context.Certificates == null)
          {
              return NotFound();
          }
            var certificate = await _context.Certificates.FindAsync(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return certificate;
        }

        // PUT: api/Certificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(Guid id, Certificates certificate)
        {
            if (id != certificate.CertificateId)
            {
                return BadRequest();
            }

            _context.Entry(certificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
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

        // POST: api/Certificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Certificates>> PostCertificate(Certificates certificate)
        {
          if (_context.Certificates == null)
          {
              return Problem("Entity set 'OC_DBContext.Certificates'  is null.");
          }
            _context.Certificates.Add(certificate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificateExists(certificate.CertificateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificate", new { id = certificate.CertificateId }, certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(Guid id)
        {
            if (_context.Certificates == null)
            {
                return NotFound();
            }
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificateExists(Guid id)
        {
            return (_context.Certificates?.Any(e => e.CertificateId == id)).GetValueOrDefault();
        }
    }
}
