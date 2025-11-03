using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class SexoController : Controller
    {
        private readonly ISexoRepository _sexoRepository;
        public SexoController(ISexoRepository sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _sexoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                await _sexoRepository.Create(sexo);
                return RedirectToAction("Index");
            }
            return View(sexo);
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

            var sexo = await _sexoRepository.GetById(id.Value);

            if (sexo is null)
                return NotFound();

            return View(sexo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Sexo sexo)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != sexo.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _sexoRepository.Update(sexo);
                return RedirectToAction("Index");
            }
            return View(sexo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var sexo = await _sexoRepository.GetById(id.Value);
            if (sexo is null)
                return NotFound();

            await _sexoRepository.Delete(sexo);
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
