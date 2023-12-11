using AutoMapper;
using myFinance_web_dotnet.Infrastructure;
using myFinance_web_dotnet.Models;
using myFinance_web_dotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace myFinance_web_dotnet.Services
{
    public class TransacaoService : ITransacaoService
    {

        private readonly MyFinanceDbContext _myFinanceDbContext;

        private readonly IMapper _mapper;

        public TransacaoService(
            MyFinanceDbContext myFinanceDbContext,
            IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First(); //lambda pra dizer que quero so quero o id, que seja igual ao id que estou recebendo "x.Id == id"
            _myFinanceDbContext.Transacao.Attach(item);
            _myFinanceDbContext.Transacao.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public IEnumerable<TransacaoModel> ListarTransacoes()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.ToList();
            var lista = _mapper.Map<IEnumerable<TransacaoModel>>(listaTransacao);
            return lista;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var listaTransacao = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First(); //lambda pra dizer que quero so quero o id, que seja igual ao id que estou recebendo "x.Id == id"
            var lista = _mapper.Map<TransacaoModel>(listaTransacao);
            return lista;
        }

        public void Salvar(TransacaoModel model)
        {
            var instancia = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
                Tipo = model.Tipo
            };

            if (instancia.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(instancia);
            }
            else
            {
                _myFinanceDbContext.Transacao.Attach(instancia);
                _myFinanceDbContext.Entry(instancia).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }
    }
}
