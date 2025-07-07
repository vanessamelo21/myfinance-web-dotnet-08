using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_08.Domain
{
    [Table("transacao")]
    public class Transacao  
    {
        public int Id { get; set; }
        public string Historico { get; set; }
        public DateOnly Data { get; set; }
        public double Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }
    }
} 