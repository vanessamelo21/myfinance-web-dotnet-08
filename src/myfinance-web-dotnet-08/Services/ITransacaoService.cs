using myfinance_web_dotnet_08.Domain;
using System.Collections.Generic;

namespace myfinance_web_dotnet_08.Services
{
    public interface ITransacaoService
    {
        void Excluir(int id);
        List<Transacao> ListarRegistros();
        Transacao RetornarRegistro(int id);
        void Salvar(Transacao registro);
    }
} 