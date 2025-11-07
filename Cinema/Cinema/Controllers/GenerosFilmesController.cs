using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Controllers
{
    public class GenerosFilmesController : Controller
    {
        private readonly IGenerosFilmesRepository _generosFilmesRepo;
        private readonly IFilmeRepository _filmeRepo;
        private readonly IGeneroRepository _generoRepo;

        public GenerosFilmesController(
            IGenerosFilmesRepository generosFilmesRepo,
            IFilmeRepository filmeRepo,
            IGeneroRepository generoRepo)
        {
            _generosFilmesRepo = generosFilmesRepo;
            _filmeRepo = filmeRepo;
            _generoRepo = generoRepo;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _generosFilmesRepo.GetAll();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            var filmes = await _filmeRepo.GetAll();
            var generos = await _generoRepo.GetAll();

            ViewBag.FilmeId = new SelectList(filmes, "Id", "Titulo");
            ViewBag.GeneroId = new SelectList(generos, "Id", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenerosFilmes generosFilmes)
        {
            if (ModelState.IsValid)
            {
                await _generosFilmesRepo.Create(generosFilmes);
                return RedirectToAction(nameof(Index));
            }

            var filmes = await _filmeRepo.GetAll();
            var generos = await _generoRepo.GetAll();

            ViewBag.FilmeId = new SelectList(filmes, "Id", "Titulo", generosFilmes.FilmeId);
            ViewBag.GeneroId = new SelectList(generos, "Id", "Nome", generosFilmes.GeneroId);

            return View(generosFilmes);
        }

        public async Task<IActionResult> Delete(int generoId, int filmeId)
        {
            var relacao = await _generosFilmesRepo.GetById(generoId, filmeId);
            if (relacao == null)
                return NotFound();

            return View(relacao);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int generoId, int filmeId)
        {
            var relacao = await _generosFilmesRepo.GetById(generoId, filmeId);
            if (relacao != null)
                await _generosFilmesRepo.Delete(relacao);

            return RedirectToAction(nameof(Index));
        }
    }
}
