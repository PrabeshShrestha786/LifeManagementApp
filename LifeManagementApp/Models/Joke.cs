namespace LifeManagementApp.Models;

public class Joke
{
    public string Content { get; set; } = string.Empty;

    public override string ToString() => Content;
}
