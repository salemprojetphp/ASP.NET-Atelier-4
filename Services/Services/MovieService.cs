using System.Collections.Generic;
using System.Threading.Tasks;
using _.Models;
using _.Repositories;
using _.Services;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> _movieRepository;
    private readonly IRepository<Genre> _genreRepository;

    public MovieService(IRepository<Movie> movieRepository, IRepository<Genre> genreRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _movieRepository.GetAllAsync();
    }
    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        return await _genreRepository.GetAllAsync();
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

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        //Methode1: retourner la liste des films puis filtrer
            // var movies = await _movieRepository.GetAllAsync();
            // return movies.Where(m => m.GenreId == genreId).ToList();
        //Methode2: ordonner directement avec une methode WHERE dans le repository
        return await _movieRepository.Where(m => m.GenreId == genreId);
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesOrderedAsync(){
        //Methode1: retourner la liste des films puis ordonner
            // var movies = await _movieRepository.GetAllAsync();
            // return movies.OrderBy(m => m.Name).ToList();
        //Methode2: ordonner directement avec une methode ORDERBY dans le repository
        return await _movieRepository.OrderBy(m => m.Name);
        
    } 
}

