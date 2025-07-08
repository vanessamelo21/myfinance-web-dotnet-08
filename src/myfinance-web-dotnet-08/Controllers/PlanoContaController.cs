using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_08.Domain;
using myfinance_web_dotnet_08.Models;
using myfinance_web_dotnet_08.Services;
using Microsoft.Extensions.Logging;

namespace myfinance_web_dotnet_08.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
        private readonly ILogger<PlanoContaController> _logger; 
        private readonly IPlanoContaService _PlanoContaService;

        public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService PlanoContaService)
        {
            _logger = logger;
            _PlanoContaService = PlanoContaService;
        }

        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Lista = _PlanoContaService.ListarRegistros();
            return View();
        }

        [HttpPost]
        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public ActionResult Cadastro(PlanoContaModel? model, int? id)
        {
            if (id != null && !ModelState.IsValid)
            {
                // Carregar o registro em tela para edição
                var registro = _PlanoContaService.RetornarRegistro((int)id);
                var planoContaModel = new PlanoContaModel()
                {   
                    Id = registro.Id,
                    Nome = registro.Nome,
                    Tipo = registro.Tipo
                };
                return View(planoContaModel);
            }
            else if (model != null && ModelState.IsValid)
            {
                var planoConta = new PlanoConta
                {
                    Id = model.Id ?? 0,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };
                _PlanoContaService.Salvar(planoConta);
                return RedirectToAction("Index");           
            }
            return View();  
        }
        
        [HttpGet]
        [Route("Excluir/{id}")]
        public ActionResult Excluir(int id)
        {
            _PlanoContaService.Excluir(id);
            return RedirectToAction("Index");
        }
    }       

 