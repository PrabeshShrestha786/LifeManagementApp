namespace LifeManagementApp;

public partial class MainPage : ContentPage
{
    private readonly List<string> notes = new();

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        var noteText = NoteEditor.Text?.Trim();
        if (string.IsNullOrEmpty(noteText))
        {
            DisplayAlert("Empty Note", "Please write something before saving.", "OK");
            return;
        }

        notes.Add(noteText);
        NoteEditor.Text = string.Empty;

        UpdateNotesList();
    }

    private void UpdateNotesList()
    {
        NotesList.Children.Clear();
        foreach (var note in notes)
        {
            NotesList.Children.Add(new Label
            {
                Text = note,
                FontSize = 16,
                TextColor = Colors.Black,  // 👈 Add this line
                BackgroundColor = Colors.LightYellow,
                Padding = 10,
                Margin = new Thickness(0, 0, 0, 5),
                LineBreakMode = LineBreakMode.WordWrap
            });

        }
    }
}
