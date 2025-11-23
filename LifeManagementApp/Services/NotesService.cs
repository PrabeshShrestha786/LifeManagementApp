using LifeManagementApp.Data;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeManagementApp.Services;

public class NotesService : INotesService
{
    private readonly NotesDbContext _db;

    public NotesService(NotesDbContext db)
    {
        _db = db;
    }

    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _db.Notes
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task AddNoteAsync(Note note)
    {
        _db.Notes.Add(note);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateNoteAsync(Note note)
    {
        _db.Notes.Update(note);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(Note note)
    {
        _db.Notes.Remove(note);
        await _db.SaveChangesAsync();
    }
}
    