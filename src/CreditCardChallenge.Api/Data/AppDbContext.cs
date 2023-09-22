using CreditCardChallenge.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCardChallenge.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CardDetails> CardDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CardDetails>().ToTable(nameof(CardDetails));
    }
}
