using Cinema.Models;
using Cinema.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class ClassificacaoController : Controller
    {
        private readonly IClassificacaoRepository _classificacaoRepository;
        public ClassificacaoController(IClassificacaoRepository classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
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
        public async Task<IActionResult> Create(Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                await _classificacaoRepository.Create(classificacao);
                return RedirectToAction("Index");
            }
            return View(classificacao);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var classificacao = await _classificacaoRepository.GetById(id.Value);
            if (classificacao is null)
                return NotFound();

            return View(classificacao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Classificacao classificacao)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != classificacao.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _classificacaoRepository.Update(classificacao);
                return RedirectToAction("Index");
            }
            return View(classificacao);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var classificacao = await _classificacaoRepository.GetById(id.Value);
            if (classificacao is null)
                return NotFound();

            await _classificacaoRepository.Delete(classificacao);
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
