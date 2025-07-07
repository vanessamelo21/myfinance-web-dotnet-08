using myfinance_web_dotnet_08.Domain;
using System.Collections.Generic;

namespace myfinance_web_dotnet_08.Services
{
    public interface IPlanoContaService
    {
        void Excluir(int id);
        List<PlanoConta> ListarRegistros();
        PlanoConta RetornarRegistro(int id);
        void Salvar(PlanoConta registro);
    }
} 