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
    public class UserCartsController : ControllerBase
    {
        private readonly OC_DBContext _context;

        public UserCartsController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/UserCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCart>>> GetUserCarts()
        {
          if (_context.UserCart == null)
          {
              return NotFound();
          }
            return await _context.UserCart.ToListAsync();
        }

        // GET: api/UserCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCart>> GetUserCart(Guid id)
        {
          if (_context.UserCart == null)
          {
              return NotFound();
          }
            var userCart = await _context.UserCart.FindAsync(id);

            if (userCart == null)
            {
                return NotFound();
            }

            return userCart;
        }

        // PUT: api/UserCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCart(Guid id, UserCart userCart)
        {
            if (id != userCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCartExists(id))
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

        // POST: api/UserCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCart>> PostUserCart(UserCart userCart)
        {
          if (_context.UserCart == null)
          {
              return Problem("Entity set 'OC_DBContext.UserCarts'  is null.");
          }
            _context.UserCart.Add(userCart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCartExists(userCart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCart", new { id = userCart.Id }, userCart);
        }

        // DELETE: api/UserCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCart(Guid id)
        {
            if (_context.UserCart == null)
            {
                return NotFound();
            }
            var userCart = await _context.UserCart.FindAsync(id);
            if (userCart == null)
            {
                return NotFound();
            }

            _context.UserCart.Remove(userCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCartExists(Guid id)
        {
            return (_context.UserCart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
