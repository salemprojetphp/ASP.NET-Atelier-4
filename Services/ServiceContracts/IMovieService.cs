using _.Models;
namespace _.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Genre>> GetAllGenresAsync();
    Task<Movie> GetMovieByIdAsync(int id);
    Task AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
    Task<bool> MovieExistsAsync(int id);
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Task<IEnumerable<Movie>> GetAllMoviesOrderedAsync();

}
