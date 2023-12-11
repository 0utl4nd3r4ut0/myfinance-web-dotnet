using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myFinance_web_dotnet;

using myFinance_web_dotnet.Domain;

namespace myFinance_web_dotnet.Services
{
    public interface IPlanoContasService
    {
        IEnumerable<PlanoConta> ListarPlanoContas();
    }
}