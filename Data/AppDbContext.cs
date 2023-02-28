using Microsoft.EntityFrameworkCore;

namespace WeightTracker.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Measurement> Mesurements { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Filename=weight_tracker.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasMany(u => u.Measurements)
            .WithOne(m => m.User)
            .IsRequired()
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Measurement>()
            .HasIndex(nameof(Measurement.TakenOn), nameof(Measurement.UserId))
            .IsUnique();
    }
}