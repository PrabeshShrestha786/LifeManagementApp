using LifeManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeManagementApp.Data;

public class NotesDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    private readonly string _dbPath;

    public NotesDbContext()
    {
        var folder = FileSystem.AppDataDirectory;
        _dbPath = Path.Combine(folder, "notes.db");

        // Ensure DB exists
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={_dbPath}");
    }
}
