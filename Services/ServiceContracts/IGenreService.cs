using _.Models;
namespace _.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenresAsync();
    Task<Genre> GetGenreByIdAsync(int id);
    Task AddGenreAsync(Genre genre);
    Task UpdateGenreAsync(Genre genre);
    Task DeleteGenreAsync(int id);
    Task<bool> GenreExistsAsync(int id);
}
