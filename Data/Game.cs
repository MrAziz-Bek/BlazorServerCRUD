namespace BlazorServerCRUD.Data;

public class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Developer { get; set; } = string.Empty;

    public DateOnly? Release { get; set; }
}