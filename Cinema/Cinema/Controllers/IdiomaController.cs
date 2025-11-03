using Cinema.Repository;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly IIdiomaRepository _idiomaRepository;
        public IdiomaController(IIdiomaRepository idiomaRepository)
        {
            _idiomaRepository = idiomaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _idiomaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                await _idiomaRepository.Create(idioma);
                return RedirectToAction("Index");
            }
            return View(idioma);
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

            var idioma = await _idiomaRepository.GetById(id.Value);

            if (idioma is null)
                return NotFound();

            return View(idioma);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Idioma idioma)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != idioma.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _idiomaRepository.Update(idioma);
                return RedirectToAction("Index");
            }
            return View(idioma);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var idioma = await _idiomaRepository.GetById(id.Value);
            if (idioma is null)
                return NotFound();

            await _idiomaRepository.Delete(idioma);
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
