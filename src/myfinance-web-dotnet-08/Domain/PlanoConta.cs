using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_08.Domain
{
    [Table("planoconta")]   
    public class PlanoConta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
} 