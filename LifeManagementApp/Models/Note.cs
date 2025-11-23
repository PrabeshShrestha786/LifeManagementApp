namespace LifeManagementApp.Models;

public class Note
{
    public int Id { get; set; }       // Primary Key
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
