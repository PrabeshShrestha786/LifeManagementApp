using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;

namespace LifeManagementApp.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    private readonly IJokeService _jokeService;

    // Joke of the day text
    [ObservableProperty]
    private string jokeOfTheDay = "Loading joke...";

    // The text currently being typed in the editor
    [ObservableProperty]
    private string newNoteText = string.Empty;

    // List of saved notes
    [ObservableProperty]
    private ObservableCollection<Note> notes = new();

    // Constructor with DI
    public NotesViewModel(IJokeService jokeService)
    {
        _jokeService = jokeService;
    }

    // Called from MainPage.OnAppearing
    public async Task InitializeAsync()
    {
        var jokes = await _jokeService.GetJokesAsync();
        JokeOfTheDay = jokes.Count > 0
            ? jokes[0].ToString()
            : "No joke today 😢";
    }

    // This becomes SaveCommand
    [RelayCommand]
    private void Save()
    {
        var text = NewNoteText?.Trim();
        if (string.IsNullOrEmpty(text))
        {
            // Ignore empty notes
            return;
        }

        Notes.Add(new Note
        {
            Text = text,
            CreatedAt = DateTime.Now
        });

        NewNoteText = string.Empty;
    }
}
