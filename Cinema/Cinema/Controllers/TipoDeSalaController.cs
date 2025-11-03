using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class TipoDeSalaController : Controller
    {
        private readonly ITipoDeSalaRepository _tipoDeSalaRepository;
        public TipoDeSalaController(ITipoDeSalaRepository tipoDeSalaRepository)
        {
            _tipoDeSalaRepository = tipoDeSalaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _tipoDeSalaRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoDeSala tipoDeSala)
        {
            if (ModelState.IsValid)
            {
                await _tipoDeSalaRepository.Create(tipoDeSala);
                return RedirectToAction("Index");
            }
            return View(tipoDeSala);
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

            var tipoDeSala = await _tipoDeSalaRepository.GetById(id.Value);

            if (tipoDeSala is null)
                return NotFound();

            return View(tipoDeSala);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, TipoDeSala tipoDeSala)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != tipoDeSala.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _tipoDeSalaRepository.Update(tipoDeSala);
                return RedirectToAction("Index");
            }
            return View(tipoDeSala);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var tipoDeSala = await _tipoDeSalaRepository.GetById(id.Value);
            if (tipoDeSala is null)
                return NotFound();

            await _tipoDeSalaRepository.Delete(tipoDeSala);
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
