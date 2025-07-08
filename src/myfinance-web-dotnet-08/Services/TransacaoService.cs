using myfinance_web_dotnet_08.Domain;
using myfinance_web_dotnet_08.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_dotnet_08.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyfinanceDbContext _banco;

        public TransacaoService(MyfinanceDbContext banco)
        {
            _banco = banco;
        }

        public void Excluir(int id)
        {
            var item = RetornarRegistro(id);
            if (item != null)
            {
                _banco.Transacoes.Remove(item);
                _banco.SaveChanges();
            }
        }

        public List<Transacao> ListarRegistros()
        {
            return _banco.Transacoes.Include(x => x.PlanoConta).ToList();
        }

        public Transacao RetornarRegistro(int id)
        {
            return _banco.Transacoes.Include(x => x.PlanoConta).Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Transacao registro)
        {
            if (registro.Id == null)
            {
                _banco.Transacoes.Add(registro);
            }
            else
            {
                _banco.Transacoes.Attach(registro);
                _banco.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _banco.SaveChanges();
        }
    }
} 