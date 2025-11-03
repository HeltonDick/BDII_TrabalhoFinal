using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        //private readonly IOficioRepository _oficioRepository;
        private readonly ISexoRepository _sexoRepository;
        public PessoaController
        (
            IPessoaRepository pessoaRepository,
            //IOficioRepository oficioRepository, 
            ISexoRepository sexoRepository

        )
        {
            _pessoaRepository = pessoaRepository;
            //_oficioRepository = oficioRepository;
            _sexoRepository = sexoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _pessoaRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Sexos = new SelectList(await _sexoRepository.GetAll(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _pessoaRepository.Create(pessoa);
                return RedirectToAction("Index");
            }
            ViewBag.Sexos = new SelectList(await _sexoRepository.GetAll(), "Id", "Nome", pessoa.SexoId);
            return View(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var pessoa = await _pessoaRepository.GetById(id.Value);

            if (pessoa == null)
                return NotFound();

            ViewBag.Sexos = new SelectList(await _sexoRepository.GetAll(), "Id", "Nome", pessoa.SexoId);
            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Pessoa pessoa)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != pessoa.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _pessoaRepository.Update(pessoa);
                return RedirectToAction("Index");
            }

            ViewBag.Sexos = new SelectList(await _sexoRepository.GetAll(), "Id", "Nome", pessoa.SexoId);
            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var pessoa = await _pessoaRepository.GetById(id.Value);

            if (pessoa == null)
                return NotFound();

            await _pessoaRepository.Delete(pessoa);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
