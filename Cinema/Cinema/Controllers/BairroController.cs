using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class BairroController : Controller
    {
        private readonly IBairroRepository _bairroRepository;
        public BairroController(IBairroRepository bairroRepository)
        {
            _bairroRepository = bairroRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _bairroRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                await _bairroRepository.Create(bairro);
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bairro = await _bairroRepository.GetById(id.Value);
            if (bairro is null)
                return NotFound();

            return View(bairro);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Bairro bairro)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != bairro.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _bairroRepository.Update(bairro);
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bairro = await _bairroRepository.GetById(id.Value);
            if (bairro is null)
                return NotFound();

            await _bairroRepository.Delete(bairro);
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
