using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class OficioController : Controller
    {
        private readonly IOficioRepository _oficioRepository;
        public OficioController(IOficioRepository oficioRepository)
        {
            _oficioRepository = oficioRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oficio oficio)
        {
            if (ModelState.IsValid)
            {
                await _oficioRepository.Create(oficio);
                return RedirectToAction("Index");
            }
            return View(oficio);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var oficio = await _oficioRepository.GetById(id.Value);
            if (oficio is null)
                return NotFound();

            return View(oficio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Oficio oficio)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != oficio.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _oficioRepository.Update(oficio);
                return RedirectToAction("Index");
            }
            return View(oficio);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var oficio = await _oficioRepository.GetById(id.Value);
            if (oficio is null)
                return NotFound();

            await _oficioRepository.Delete(oficio);
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
