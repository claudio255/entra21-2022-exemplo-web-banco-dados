using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    [Route("/veterinario")]
    public class VeterinarioController : Controller
    {
        private readonly IVeterinarioServico _veterinarioServico;

        public VeterinarioController(IVeterinarioServico veterinarioServico)
        {
            _veterinarioServico = veterinarioServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/cadastrara")]
        public IActionResult Cadastrar(VeterinarioCadastrarViewModel veterinarioCadastraraViewModel)
        {
            if (!ModelState.IsValid)
                return View(veterinarioCadastraraViewModel);

            //Criar o registro chamando o serviço
            _veterinarioServico.Cadastrar(veterinarioCadastraraViewModel);

            //Redirecionar para index
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
    }
}
