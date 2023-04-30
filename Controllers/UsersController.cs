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
    // GET: Users/Details/5
    // public async Task<IActionResult> Details(int? id)
    // {
    //     if (id == null || _context.Users == null)
    //     {
    //         return NotFound();
    //     }

    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(m => m.user_id == id);
    //     if (user == null)
    //     {
    //         return NotFound();
    //     }

    //     return View(user);
    // }

    // GET: Users/Create
    // public IActionResult Create()
    // {
    //     return View();
    // }

    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Create([Bind("user_id,user_name,user_password,user_telephone,user_img,user_created_date,user_created_by,user_updated_date,user_updated_by")] User user)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Add(user);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(user);
    // }

    // GET: Users/Edit/5
    // public async Task<IActionResult> Edit(int? id)
    // {
    //     if (id == null || _context.Users == null)
    //     {
    //         return NotFound();
    //     }

    //     var user = await _context.Users.FindAsync(id);
    //     if (user == null)
    //     {
    //         return NotFound();
    //     }
    //     return View(user);
    // }

    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Edit(int id, [Bind("user_id,user_name,user_password,user_telephone")] User user)
    // {
    //     if (id != user.user_id)
    //     {
    //         return NotFound();
    //     }

    //     if (ModelState.IsValid)
    //     {
    //         try
    //         {
    //             _context.Update(user);
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!UserExists(user.user_id))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(user);
    // }

    // GET: Users/Delete/5
    // public async Task<IActionResult> Delete(int? id)
    // {
    //     if (id == null || _context.Users == null)
    //     {
    //         return NotFound();
    //     }

    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(m => m.user_id == id);
    //     if (user == null)
    //     {
    //         return NotFound();
    //     }

    //     return View(user);
    // }

    // POST: Users/Delete/5
    // [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> DeleteConfirmed(int id)
    // {
    //     if (_context.Users == null)
    //     {
    //         return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
    //     }
    //     var user = await _context.Users.FindAsync(id);
    //     if (user != null)
    //     {
    //         _context.Users.Remove(user);
    //     }

    //     await _context.SaveChangesAsync();
    //     return RedirectToAction(nameof(Index));
    // }

    // private bool UserExists(int id)
    // {
    //   return (_context.Users?.Any(e => e.user_id == id)).GetValueOrDefault();
    // }
  }
}
