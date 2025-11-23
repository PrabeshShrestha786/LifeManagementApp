using LifeManagementApp.Models;

namespace LifeManagementApp.Interfaces;

public interface INotesService
{
    Task<List<Note>> GetAllNotesAsync();
    Task AddNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(Note note);
}
