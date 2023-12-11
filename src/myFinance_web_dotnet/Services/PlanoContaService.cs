using AutoMapper;
using myFinance_web_dotnet.Infrastructure;
using myFinance_web_dotnet.Models;
using myFinance_web_dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace myFinance_web_dotnet.Services
{
    public class PlanoContaService : IPlanoContasService
    {

        private readonly MyFinanceDbContext _myFinanceDbContext;

        private readonly IMapper _mapper;
        public PlanoContaService(
            MyFinanceDbContext myFinanceDbContext,
            IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First(); //lambda pra dizer que quero so quero o id, que seja igual ao id que estou recebendo "x.Id == id"
            _myFinanceDbContext.PlanoConta.Attach(item);
            _myFinanceDbContext.PlanoConta.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public IEnumerable<PlanoContaModel> ListarPlanoContas()
        {
            var listaPlanoConta = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(listaPlanoConta);
            return lista;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var listaPlanoConta = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First(); //lambda pra dizer que quero so quero o id, que seja igual ao id que estou recebendo "x.Id == id"
            var lista = _mapper.Map<PlanoContaModel>(listaPlanoConta);
            return lista;
        }

        public void Salvar(PlanoContaModel model)
        {
            var instancia = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            if (instancia.Id == null)
            {
                _myFinanceDbContext.PlanoConta.Add(instancia);
            }
            else
            {
                _myFinanceDbContext.PlanoConta.Attach(instancia);
                _myFinanceDbContext.Entry(instancia).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }
    }
}
