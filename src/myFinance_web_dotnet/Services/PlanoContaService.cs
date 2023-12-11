using myFinance_web_dotnet.Domain;
using myFinance_web_dotnet.Infrastructure;

namespace myFinance_web_dotnet.Services
{
        public class PlanoContaService : IPlanoContasService
        {

            private readonly MyFinanceDbContext _myFinanceDbContext;
            public PlanoContaService(MyFinanceDbContext myFinanceDbContext){
                _myFinanceDbContext = myFinanceDbContext;
            }

            public IEnumerable<PlanoConta> ListarPlanoContas()
            {
                return _myFinanceDbContext.PlanoConta;
            }
        }
    }
