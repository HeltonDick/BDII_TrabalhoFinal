using Cinema.Models;
using Cinema.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class OficioPessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IOficioRepository _oficioRepository;
        private readonly IOficiosDePessoasRepository _oficioDePessoaRepository;

        public OficioPessoaController(
            IPessoaRepository pessoaRepository,
            IOficioRepository oficioRepository,
            IOficiosDePessoasRepository oficioDePessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
            _oficioRepository = oficioRepository;
            _oficioDePessoaRepository = oficioDePessoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = (await _oficioDePessoaRepository.GetAll())
                .Select(x => new
                {
                    x.Id,
                    PessoaNome = x.Pessoa.PrimeiroNome + " " + x.Pessoa.UltimoNome,
                    OficioNome = x.Oficio.Nome
                }).ToList();

            ViewBag.Relacoes = lista;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Pessoas = new SelectList(await _pessoaRepository.GetAll(), "Id", "PrimeiroNome");
            ViewBag.Oficios = new SelectList(await _oficioRepository.GetAll(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OficiosDePessoas relacao)
        {
            if (ModelState.IsValid)
            {
                await _oficioDePessoaRepository.Create(relacao);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Pessoas = new SelectList(await _pessoaRepository.GetAll(), "Id", "PrimeiroNome");
            ViewBag.Oficios = new SelectList(await _oficioRepository.GetAll(), "Id", "Nome");

            return View(relacao);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var relacao = (await _oficioDePessoaRepository.GetAll()).FirstOrDefault(x => x.Id == id);
            if (relacao != null)
            {
                await _oficioDePessoaRepository.Delete(relacao);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
