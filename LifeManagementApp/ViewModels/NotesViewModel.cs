using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;

namespace LifeManagementApp.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    private readonly IJokeService _jokeService;
    private readonly INotesService _notesService;

    // Joke of the day
    [ObservableProperty]
    private string jokeOfTheDay = "Loading joke...";

    // Text from the Editor
    [ObservableProperty]
    private string newNoteText = string.Empty;

    // Notes collection bound to UI
    [ObservableProperty]
    private ObservableCollection<Note> notes = new();

    public NotesViewModel(IJokeService jokeService, INotesService notesService)
    {
        _jokeService = jokeService;
        _notesService = notesService;
    }

    // Load joke + notes (called in MainPage.OnAppearing)
    public async Task InitializeAsync()
    {
        // Joke of the day
        var jokes = await _jokeService.GetJokesAsync();
        JokeOfTheDay = jokes.FirstOrDefault()?.ToString() ?? "No joke today 😢";

        // Load notes from SQLite db
        var allNotes = await _notesService.GetAllNotesAsync();
        Notes.Clear();

        foreach (var n in allNotes)
            Notes.Add(n);
    }

    // SAVE COMMAND (async)
    [RelayCommand]
    private async Task Save()
    {
        var text = NewNoteText?.Trim();
        if (string.IsNullOrEmpty(text))
            return;

        var newNote = new Note
        {
            Text = text,
            CreatedAt = DateTime.Now
        };

        // Save to database
        await _notesService.AddNoteAsync(newNote);

        // Add to observable list (top of list)
        Notes.Insert(0, newNote);

        // Clear editor
        NewNoteText = string.Empty;
    }
}
