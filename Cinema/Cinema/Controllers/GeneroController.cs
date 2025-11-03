using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _generoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genero genero)
        {
            if (ModelState.IsValid)
            {
                await _generoRepository.Create(genero);
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var genero = await _generoRepository.GetById(id.Value);

            if (genero is null)
                return NotFound();

            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Genero genero)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != genero.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _generoRepository.Update(genero);
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var genero = await _generoRepository.GetById(id.Value);
            if (genero is null)
                return NotFound();

            await _generoRepository.Delete(genero);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
