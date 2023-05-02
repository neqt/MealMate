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
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
          if (_context.Posts == null)   
          {
              return NotFound();
          }
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.post_id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Post>> CreatePost([Bind("poster_id,quantity,status")] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int maxPostId = _context.Posts.Any() ? _context.Posts.Max(p => p.post_id) : 0;
                    post.post_id = maxPostId + 1;
                    post.start_date = DateTime.UtcNow;
                    post.quantity = 0;
                    post.status = '1';// TODO integrate with status enum
                    await _context.Posts.AddAsync(post);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetPostById), new { id = post.post_id }, post);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to create record: {ex.Message}");
            }
            return NotFound();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.post_id == id)).GetValueOrDefault();
        }
    }
}
