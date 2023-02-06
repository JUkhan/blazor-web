using System;
using BlazorWeb.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.DAL.Persistence
{
  public class DataContext : DbContext
  {

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite($"Data Source=order.db");

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Window> Windows { get; set; }
    public DbSet<Element> Elements { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<EntityBase>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.CreatedBy = "jukhan";
            break;
          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = "jukhan";
            break;
        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Order>()
          .HasMany(t => t.Windows)
          .WithOne(c => c.Order)
          .HasForeignKey(c => c.OrderId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Window>()
        .HasMany(t => t.Elements)
        .WithOne(c => c.Window)
        .HasForeignKey(c => c.WindowId)
        .OnDelete(DeleteBehavior.Cascade);
    }

  }
}

