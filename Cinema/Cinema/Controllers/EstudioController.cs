using Cinema.Models;
using Cinema.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;
        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
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
        public async Task<IActionResult> Create(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.Create(estudio);
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var estudio = await _estudioRepository.GetById(id.Value);
            if (estudio is null)
                return NotFound();

            return View(estudio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Estudio estudio)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != estudio.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _estudioRepository.Update(estudio);
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var estudio = await _estudioRepository.GetById(id.Value);
            if (estudio is null)
                return NotFound();

            await _estudioRepository.Delete(estudio);
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
