using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mealmate.Context;
using mealmate.Models;

namespace mealmate.Controllers
{
  public class UsersController : Controller
  {
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
      return _context.Users != null ?
                View(await _context.Users.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Users'  is null.");
    }

    [HttpGet]
    [Route("greet")]
    public async Task<IActionResult> HelloWorld()
    {
      return await Task.FromResult(Ok("Hello, world!"));
    }

    [HttpGet]
    [Route("user/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user != null)
      {
        return Ok(user);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpPost]
    [Route("user/regis")]
    public async Task<IActionResult> CreateNewUser([FromBody] User user)
    {
      if (ModelState.IsValid)
      {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserById), new { id = user.user_id }, user);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpGet]
    [Route("api/users")]
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }
  }
}
