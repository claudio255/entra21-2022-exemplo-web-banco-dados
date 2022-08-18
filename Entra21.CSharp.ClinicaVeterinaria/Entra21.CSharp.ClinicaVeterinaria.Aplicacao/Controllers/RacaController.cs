using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enums;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    //Dois pontos Herança(mais pra frente)
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;

        //Construtor: Objetivo construir o objeto de RacaController, com o mínimo necessário para o funcionamento correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// EndPoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [HttpGet("/raca")]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            //Passar informações do C# para o HTML
            ViewBag.Racas = racas;

            return View("Index");
        }

        [HttpGet("/raca/cadastrar")]
        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();

            ViewBag.Especies = especies;

            return View();
        }

        [HttpPost("/raca/cadastrar")]
        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModel racaCadastrarViewModel)
        {
            _racaServico.Cadastrar(racaCadastrarViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/apagar")]
        // https://localhost:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery]int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/editar")]
        public IActionResult Editar([FromQuery]int id)
        {
            var raca = _racaServico.ObterPorId(id);
            var especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especies = especies;

            return View("Editar");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>().OrderBy(x => x).ToList();
        }

        [HttpPost("raca/editar")]
        public IActionResult Editar([FromForm] RacaEditarViewModel racaEditarViewModel)
        {
            _racaServico.Editar(racaEditarViewModel);

            return RedirectToAction("Index");
        }
    }
}
