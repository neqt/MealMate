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
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
          if (_context.Orders == null)   
          {
              return NotFound();
          }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Order>> CreateNewOrder([Bind("post_id,poster_id,food_name,notes,quantity,order_owner_id,status,latest_update")] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int maxOrderId = _context.Orders.Any() ? _context.Orders.Max(o => o.order_id) : 0;
                    order.order_id = maxOrderId + 1;
                    order.latest_update = DateTime.UtcNow;
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetOrderById), new { id = order.order_id }, order);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to create record: {ex.Message}");
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
    
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.order_id == id)).GetValueOrDefault();
        }
    }
}
