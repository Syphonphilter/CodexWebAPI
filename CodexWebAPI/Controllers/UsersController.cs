using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodexWebAPI.Models;
using System.IO;

namespace CodexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OC_DBContext _context;
        // set permutations
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;

        public UsersController(OC_DBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        public static string Encrypt(string strData)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
            // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

        }


        // decoding
        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
            // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx

        }

        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] { bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                         bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }


        [HttpGet("validate/{email}/{password}")]
        public async Task<ActionResult<string>> validateuser(string email, string password)
        {
            var user = email.ToString();
            var usercheck = (from c in _context.Users where c.UserEmail == user && c.PasswordHash == Encrypt(password) select c).FirstOrDefault();
            if (usercheck != null)
            {
                return usercheck.UserId.ToString();  
            }
            else
            {
                return "invalid";
            }
        }
        // GET:api/GetUserDetails/5

        [HttpGet("GetUserDetails/{id}")]

        public async Task<ActionResult<Users>> GetUserDetails(Guid id)
        {
            var staff = _context.Users.Include(user => user.AccountType)
                .Include(user => user.SubscriptionType)
                .Include(user=> user.UserCourse)
                .Where(user => user.UserId == id).FirstOrDefault();
            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

      

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(Guid id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, Users user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserEmail))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'OC_DBContext.Users'  is null.");
          }
            var search = (from c in _context.Users where c.UserEmail == user.UserEmail select c).Count();
            if (search >= 1)
            {
                return Conflict();
            }
            else
            {
                user.PasswordHash = Encrypt(user.PasswordHash);
                user.SubscriptionTypeId = Guid.Parse("4161EB22-E05F-4864-A101-F54EE2939888");
                user.AccountTypeId = Guid.Parse("B31C5D96-0D78-4B27-8ACB-C6D67A1B5D84");
                user.UserName = user.UserEmail;
                _context.Users.Add(user);
            }
            try
            {
               
                    await _context.SaveChangesAsync();
              
               
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
       
            // DELETE: api/Users/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string email)
        {
            return (_context.Users?.Any(e => e.UserEmail == email)).GetValueOrDefault();
        }
    }
}
