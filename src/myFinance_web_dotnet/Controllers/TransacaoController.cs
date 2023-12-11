using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myFinance_web_dotnet.Domain;
using myFinance_web_dotnet.Models;
using myFinance_web_dotnet.Services;

namespace myFinance_web_dotnet.Controllers;

[Route("[Controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;

    private readonly ITransacaoService _transacaoService;

    private readonly IMapper _mapper;

    private readonly IPlanoContasService _planoContaService;

    public TransacaoController(
        ILogger<TransacaoController> logger,
        IMapper mapper,
        ITransacaoService transacaoService,
        IPlanoContasService planoContasService
        )
    {
        _logger = logger;
        _mapper = mapper;
        _transacaoService = transacaoService;
        _planoContaService = planoContasService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {

        //List<PlanoContaModel> listaPlanoContaModel = new();

        //foreach (var item in _PlanoContaService.ListarPlanoContas())
        //{
          //var planoConta = new PlanoContaModel()
          //{
            //Id = item.Id,
            //Descricao = item.Descricao,
            //Tipo = item.Tipo
          //};
          //listaPlanoContaModel.Add(planoConta);
        //}
 
        //ViewBag.ListaPlanoContas = listaPlanoContaModel;

        var listaTransacao =_transacaoService.ListarTransacoes();
        ViewBag.listaTransacao = listaTransacao;

        return View();
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(int? id)
    {
        var TransacaoModel = new TransacaoModel();

        if (id != null)
        {
            TransacaoModel = _transacaoService.RetornarRegistro((int)id);
            
            //var registro = _transacaoService.RetornarRegistro((int)id);
            //return View(registro);
        }

        var listaPlanoConta = _planoContaService.ListarPlanoContas();
        var PlanoContaselectListItens = new SelectList(listaPlanoConta, "Id", "Descricao");
        TransacaoModel.PlanoConta = PlanoContaselectListItens;

        return View(TransacaoModel);
    }

    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(TransacaoModel model)
    {
        _transacaoService.Salvar(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }


    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
