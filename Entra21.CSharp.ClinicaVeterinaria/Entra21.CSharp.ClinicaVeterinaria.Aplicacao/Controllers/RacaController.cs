using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    //Dois pontos Herança(mais pra frente)
    public class RacaController : Controller
    {
        private readonly RacaServico _racaServico;

        //Construtor: Objetivo construir o objeto de RacaController, com o mínimo necessário para o funcionamento correto
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// EndPoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [Route("/raca")]
        [HttpGet]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            //Passar informações do C# para o HTML
            ViewBag.Racas = racas;

            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("/raca/registrar")]
        [HttpGet]
        public IActionResult Registrar(
            [FromQuery] string nome,
            [FromQuery] string especie)
        {
            _racaServico.Cadastrar(nome, especie);

            return RedirectToAction("Index");
        }
            
    }
}
