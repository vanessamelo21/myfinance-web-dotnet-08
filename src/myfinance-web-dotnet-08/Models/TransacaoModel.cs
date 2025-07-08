using System.ComponentModel.DataAnnotations;
using myfinance_web_dotnet_08.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet_08.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string? Historico { get; set; }
        public string? Tipo { get; set; }
        public DateTime Data { get; set; }
        public int PlanoContaId { get; set; }
        public IEnumerable<SelectListItem>? PlanoContas { get; set; }
        public decimal Valor { get; set; }  

    }
} 