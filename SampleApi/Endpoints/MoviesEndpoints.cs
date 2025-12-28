using SampleApi.Data;
using System.Diagnostics.CodeAnalysis;

namespace SampleApi.Endpoints;
public static class MoviesEndpoints
{
    public static void AddMoviesEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", LoadAllMovies);
        app.MapGet("/movies/{id}", LoadMovieById);
    }

    private static IResult LoadAllMovies(MoviesData data, string? genre, string? search)
    {
        try
        {
            var movies = data.Movies;

            if(!String.IsNullOrWhiteSpace(genre))
            {
                movies.RemoveAll(movie => 
                    String.Compare(movie.Genre, genre, StringComparison.OrdinalIgnoreCase) != 0
                );
            }

            if (!String.IsNullOrWhiteSpace(search))
            {
                movies.RemoveAll(movie =>
                    !movie.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                    && !movie.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
                );
            }

            return Results.Ok(movies);
        }
        catch (Exception ex)
        {
            return Results.InternalServerError($"Exception thrown {ex.Message}");
        }
    }

    private static IResult LoadMovieById(MoviesData data, int id)
    {
        try
        {
            var movie = data.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movie is null)
            {
                return Results.NotFound($"{id} does not exist in the list of movies");
            }

            //throw new Exception("This is a test exception");

            return Results.Ok(data.Movies.SingleOrDefault(m => m.Id == id));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError($"Exception thrown {ex.Message}");
        }
    }
}