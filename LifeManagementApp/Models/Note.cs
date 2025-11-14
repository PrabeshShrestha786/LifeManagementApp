namespace LifeManagementApp.Models;

public class Note
{
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
