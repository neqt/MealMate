using Microsoft.EntityFrameworkCore;
using mealmate.Models;
using System;

namespace mealmate.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
  }
}
