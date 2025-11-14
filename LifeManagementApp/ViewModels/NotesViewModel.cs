using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Models;

namespace LifeManagementApp.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    // The text currently being typed in the editor
    [ObservableProperty]
    private string newNoteText = string.Empty;

    // List of saved notes
    [ObservableProperty]
    private ObservableCollection<Note> notes = new();

    public NotesViewModel()
    {
    }

    // This becomes SaveCommand
    [RelayCommand]
    private void Save()
    {
        var text = NewNoteText?.Trim();
        if (string.IsNullOrEmpty(text))
        {
            // In pure MVVM we’d use a service/message for alerts.
            // For this assignment we simply ignore empty notes.
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
