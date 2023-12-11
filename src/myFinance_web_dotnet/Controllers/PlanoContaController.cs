using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myFinance_web_dotnet.Domain;
using myFinance_web_dotnet.Models;
using myFinance_web_dotnet.Services;

namespace myFinance_web_dotnet.Controllers;

[Route("[Controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;

    private readonly IPlanoContasService _PlanoContaService;

    private readonly IMapper _mapper;

    public PlanoContaController(
        ILogger<PlanoContaController> logger,
        IMapper mapper,
        IPlanoContasService planoContasService
        )
    {
        _logger = logger;
        _mapper = mapper;
        _PlanoContaService = planoContasService;
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

        var listaPlanoConta =_PlanoContaService.ListarPlanoContas();
        var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(listaPlanoConta);
        ViewBag.ListaPlanoContas = lista;

        return View();
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(int? id)
    {
        if (id != null)
        {
            //var registro = _PlanoContaService.RetornarRegistro((int)id);
            //return View(registro);
        }
        return View();
    }

    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(PlanoContaModel model)
    {
        //_PlanoContaService.Salvar(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        //_PlanoContaService.Excluir(id);
        return RedirectToAction("Index");
    }


    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
