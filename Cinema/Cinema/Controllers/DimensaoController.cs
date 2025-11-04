using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class DimensaoController : Controller
    {
        private readonly IDimensaoRepository _dimensaoRepository;
        public DimensaoController(IDimensaoRepository dimensaoRepository)
        {
            _dimensaoRepository = dimensaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _dimensaoRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dimenssao dimensao)
        {
            if (ModelState.IsValid)
            {
                await _dimensaoRepository.Create(dimensao);
                return RedirectToAction("Index");
            }
            return View(dimensao);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var dimensao = await _dimensaoRepository.GetById(id.Value);
            if (dimensao is null)
                return NotFound();

            return View(dimensao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Dimenssao dimensao)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != dimensao.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _dimensaoRepository.Update(dimensao);
                return RedirectToAction("Index");
            }
            return View(dimensao);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var dimensao = await _dimensaoRepository.GetById(id.Value);
            if (dimensao is null)
                return NotFound();

            await _dimensaoRepository.Delete(dimensao);
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
