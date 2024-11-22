using System.Collections.Generic;
using System.Threading.Tasks;
using _.Models;
using _.Repositories;
using _.Services;

public class GenreService : IGenreService
{
    private readonly IRepository<Genre> _genreRepository;

    public GenreService(IRepository<Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        return await _genreRepository.GetAllAsync();
    }

    public async Task<Genre> GetGenreByIdAsync(int id)
    {
        return await _genreRepository.GetByIdAsync(id);
    }

    public async Task AddGenreAsync(Genre Genre)
    {
        await _genreRepository.AddAsync(Genre);
    }

    public async Task UpdateGenreAsync(Genre Genre)
    {
        await _genreRepository.UpdateAsync(Genre);
    }

    public async Task DeleteGenreAsync(int id)
    {
        await _genreRepository.DeleteAsync(id);
    }

    public async Task<bool> GenreExistsAsync(int id)
    {
        return await _genreRepository.GetByIdAsync(id) != null;
    }
}
