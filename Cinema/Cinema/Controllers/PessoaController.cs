using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IOficioRepository _oficioRepository;
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


    }
}
