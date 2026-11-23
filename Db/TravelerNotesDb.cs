using Microsoft.EntityFrameworkCore;
using TravelerNotes.Entitites;

namespace TravelerNotes.Db;

public class TravelerNotesDb:DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01;Database=TravelerNotes;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0");
    }

    //ეს დავამატე იმიტომ რომ არ მაქმნევიებდა ბაზას 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>()
            .HasOne(t => t.Place)
            .WithMany(p => p.Tags)
            .HasForeignKey(t => t.PlaceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tag>()
            .HasOne(t => t.Trip)
            .WithMany(tr => tr.Tags)
            .HasForeignKey(t => t.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}

