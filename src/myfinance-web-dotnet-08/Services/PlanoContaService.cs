using myfinance_web_dotnet_08.Domain;
using myfinance_web_dotnet_08.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace myfinance_web_dotnet_08.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyfinanceDbContext _banco;

        public PlanoContaService(MyfinanceDbContext banco)
        {
            _banco = banco;
        }

        public void Excluir(int id)
        {
            var item = RetornarRegistro(id);
            if (item != null)
            {
                _banco.PlanoContas.Remove(item);
                _banco.SaveChanges();
            }
        }

        public List<PlanoConta> ListarRegistros()
        {
            return _banco.PlanoContas.ToList(); 
        }

        public PlanoConta RetornarRegistro(int id)
        {
            return _banco.PlanoContas.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(PlanoConta registro)
        {
            if (registro.Id == 0)   
            {
                _banco.PlanoContas.Add(registro);
            }
            else
            {
                _banco.PlanoContas.Attach(registro);
                _banco.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            Console.WriteLine($"Salvando registro: {registro.Id}");
            _banco.SaveChanges();
        }
    }
} 