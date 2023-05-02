using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mealmate.Context;
using mealmate.Models;

namespace mealmate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserLoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogins()
        {
          if (_context.UserLogins == null)
          {
              return NotFound();
          }
            return await _context.UserLogins.ToListAsync();
        }

        // GET: api/UserLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(int id)
        {
          if (_context.UserLogins == null)
          {
              return NotFound();
          }
            var userLogin = await _context.UserLogins.FindAsync(id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // PUT: api/UserLogin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (id != userLogin.userLogin_id)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogin(UserLogin userLogin)
        {
          if (_context.UserLogins == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserLogins'  is null.");
          }
            _context.UserLogins.Add(userLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLogin", new { id = userLogin.userLogin_id }, userLogin);
        }

        // DELETE: api/UserLogin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogin(int id)
        {
            if (_context.UserLogins == null)
            {
                return NotFound();
            }
            var userLogin = await _context.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            _context.UserLogins.Remove(userLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginExists(int id)
        {
            return (_context.UserLogins?.Any(e => e.userLogin_id == id)).GetValueOrDefault();
        }
    }
}
