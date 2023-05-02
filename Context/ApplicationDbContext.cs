using Microsoft.EntityFrameworkCore;
using mealmate.Models;
using System;

namespace mealmate.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<UserLogin> UserLogins { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Order> Orders { get; set; }
  }
}
