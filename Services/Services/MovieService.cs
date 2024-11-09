using System.Collections.Generic;
using System.Threading.Tasks;
using _.Models;
using _.Repositories;
using _.Services;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> _movieRepository;

    public MovieService(IRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _movieRepository.GetAllAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await _movieRepository.GetByIdAsync(id);
    }

    public async Task AddMovieAsync(Movie movie)
    {
        await _movieRepository.AddAsync(movie);
    }

    public async Task UpdateMovieAsync(Movie movie)
    {
        await _movieRepository.UpdateAsync(movie);
    }

    public async Task DeleteMovieAsync(int id)
    {
        await _movieRepository.DeleteAsync(id);
    }

    public async Task<bool> MovieExistsAsync(int id)
    {
        return await _movieRepository.GetByIdAsync(id) != null;
    }
}
