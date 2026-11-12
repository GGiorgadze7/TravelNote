using Microsoft.EntityFrameworkCore;
using TravelerNotes.Entitites;

namespace TravelerNotes.Db;

public class TravelerNotesDb:DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Place> Places { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=GUGA;Integrated Security=True;Database=TravelerNotes;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0");
    }
}
