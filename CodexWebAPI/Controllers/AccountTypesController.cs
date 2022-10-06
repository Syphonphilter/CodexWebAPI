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
    public class AccountTypesController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public AccountTypesController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/AccountTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTypes>>> GetAccountTypes()
        {
          if (_context.AccountTypes == null)
          {
              return NotFound();
          }
            return await _context.AccountTypes.ToListAsync();
        }

        // GET: api/AccountTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTypes>> GetAccountType(Guid id)
        {
          if (_context.AccountTypes == null)
          {
              return NotFound();
          }
            var accountType = await _context.AccountTypes.FindAsync(id);

            if (accountType == null)
            {
                return NotFound();
            }

            return accountType;
        }

        // PUT: api/AccountTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountType(Guid id, AccountTypes accountType)
        {
            if (id != accountType.AccountTypeId)
            {
                return BadRequest();
            }

            _context.Entry(accountType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTypeExists(id))
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

        // POST: api/AccountTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountTypes>> PostAccountType(AccountTypes accountType)
        {
          if (_context.AccountTypes == null)
          {
              return Problem("Entity set 'OC_DBContext.AccountTypes'  is null.");
          }
            _context.AccountTypes.Add(accountType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountTypeExists(accountType.AccountTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountType", new { id = accountType.AccountTypeId }, accountType);
        }

        // DELETE: api/AccountTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(Guid id)
        {
            if (_context.AccountTypes == null)
            {
                return NotFound();
            }
            var accountType = await _context.AccountTypes.FindAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }

            _context.AccountTypes.Remove(accountType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountTypeExists(Guid id)
        {
            return (_context.AccountTypes?.Any(e => e.AccountTypeId == id)).GetValueOrDefault();
        }
    }
}
