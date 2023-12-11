namespace myFinance_web_dotnet.Domain
{
    public class Transacao
    {
        public int? Id {get; set;}
        public string Historico {get; set;}
        public string Tipo {get; set;}
        public double Valor {get; set;}
        public int PlanoContaId {get; set;}
        public DateTime Data {get; set;}
        public PlanoConta PlanoConta {get; set;}
    }

}