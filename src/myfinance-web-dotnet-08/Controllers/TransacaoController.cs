using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_08.Domain;
using myfinance_web_dotnet_08.Models;
using myfinance_web_dotnet_08.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet_08.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;

    public TransacaoController(ILogger<TransacaoController> logger, ITransacaoService transacaoService, IPlanoContaService planoContaService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _transacaoService.ListarRegistros();
        return View();
    }

    [HttpPost]
    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(TransacaoModel? model, int? id)
    {
        var listaPlanoContas = _planoContaService.ListarRegistros();
        var planoContaSelectItens = new SelectList(listaPlanoContas, "Id", "Nome");

        if (id != null && (!ModelState.IsValid || model?.PlanoContaId == 0))
        {
            var registro = _transacaoService.RetornarRegistro((int)id);
            var viewModel = new TransacaoModel
            {
                Id = registro.Id,
                Historico = registro.Historico,
                Tipo = registro.PlanoConta?.Tipo,
                Valor = registro.Valor,
                PlanoContaId = registro.PlanoContaId,
                PlanoContas = planoContaSelectItens
            };
            return View(viewModel);
        }
        else if (model != null && ModelState.IsValid && model.PlanoContaId != 0)
        {
            var transacao = new Transacao
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
            };
            _transacaoService.Salvar(transacao);
            return RedirectToAction("Index");
        }
        else
        {
            var viewModel = new TransacaoModel
            {
                Data = DateTime.Now,
                PlanoContas = planoContaSelectItens
            };
            return View(viewModel);
        }
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }
} 