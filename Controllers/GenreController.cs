using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _.Models;
using _.Services;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_atelier_4.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: Genre
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return View(genres);
        }

        // GET: Genre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreService.GetGenreByIdAsync(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreService.AddGenreAsync(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreService.GetGenreByIdAsync(id.Value);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _genreService.UpdateGenreAsync(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _genreService.GenreExistsAsync(genre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreService.GetGenreByIdAsync(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre != null)
            {
                await _genreService.DeleteGenreAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
