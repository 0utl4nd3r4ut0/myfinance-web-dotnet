using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myFinance_web_dotnet.Models
{
    public class TransacaoModel
    {
      
        public int? Id { get; set; }
        public string Historico { get; set; } 
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; } //persiste os valores a serem subtituidos no DB
        public DateTime Data { get; set; }
        public IEnumerable<SelectListItem> PlanoConta { get; set; } // ajuda a renderizar a tela de cadastro baseado no plano conta, o select.item serve pra renderizar uma linha no html
    }
}