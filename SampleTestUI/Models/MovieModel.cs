namespace SampleTestUI.Models;

public class MovieModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public float Rating { get; set; }
    public required string Director { get; set; }
    public int Duration { get; set; }
    public required string Description { get; set; }
}
