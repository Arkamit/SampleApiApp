using SampleApi.Models;
using System.Text.Json;

namespace SampleApi.Data;

public class MoviesData
{
    public List<MoviesModel> Movies { get; private set; }

    public MoviesData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "moviesdata.json");
        string jsonData = File.ReadAllText(filePath);

        Movies = JsonSerializer.Deserialize<List<MoviesModel>>(jsonData, options) ?? new();
    }
}
