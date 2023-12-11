using myFinance_web_dotnet.Models;

namespace myFinance_web_dotnet.Services
{
    public interface IPlanoContasService
    {
        IEnumerable<PlanoContaModel> ListarPlanoContas();

        void Salvar(PlanoContaModel model);

        PlanoContaModel RetornarRegistro(int id);

        void Excluir(int id);
    }
}