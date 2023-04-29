using Microsoft.EntityFrameworkCore;
using MealMate.Models;
using System;

namespace MealMate.Context
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
