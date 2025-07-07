using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_08.Domain;

namespace myfinance_web_dotnet_08.Infrastructure
{
    public class MyfinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoContas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=myfinance;user=myfinance;password=<your_password>;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
} 