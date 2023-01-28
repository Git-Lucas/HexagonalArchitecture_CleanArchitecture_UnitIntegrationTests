using Fatura.Domain.Models;
using Fatura.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Infra.Data.EntityFramework
{
    public class EfSqliteAdapter : DbContext
    {
        public DbSet<TransacaoCartao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.GetDirectoryName("C:\\WorkSpace\\VisualStudio\\HexagonalArchitecture_CleanArchitecture_UnitIntegrationTests\\Fatura\\");
            optionsBuilder.UseSqlite($"Data Source={path}\\Transacao.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransacaoCartao>().HasData(
                    new TransacaoCartao
                    {
                        Id = 1,
                        NumeroCartao = "1234",
                        Valor = 1200,
                        Moeda = Moeda.BRL,
                        DataCompra = DateTime.Parse($"01/{DateTime.Now.Month}/{DateTime.Now.Year}")
                    },
                    new TransacaoCartao
                    {
                        Id = 2,
                        NumeroCartao = "1234",
                        Valor = 400,
                        Moeda = Moeda.USD,
                        DataCompra = DateTime.Parse($"05/{DateTime.Now.Month}/{DateTime.Now.Year}")
                    },
                    new TransacaoCartao
                    {
                        Id = 3,
                        NumeroCartao = "4321",
                        Valor = 400,
                        Moeda = Moeda.USD,
                        DataCompra = DateTime.Parse($"05/{DateTime.Now.Month}/{DateTime.Now.Year}")
                    },
                    new TransacaoCartao
                    {
                        Id = 4,
                        NumeroCartao = "1234",
                        Valor = 200,
                        Moeda = Moeda.BRL,
                        DataCompra = DateTime.Parse($"10/{DateTime.Now.Month + 1}/{DateTime.Now.Year}")
                    },
                    new TransacaoCartao
                    {
                        Id = 5,
                        NumeroCartao = "1234",
                        Valor = 50,
                        Moeda = Moeda.USD,
                        DataCompra = DateTime.Parse($"20/{DateTime.Now.Month + 1}/{DateTime.Now.Year}")
                    },
                    new TransacaoCartao
                    {
                        Id = 6,
                        NumeroCartao = "4321",
                        Valor = 50,
                        Moeda = Moeda.USD,
                        DataCompra = DateTime.Parse($"20/{DateTime.Now.Month + 1}/{DateTime.Now.Year}")
                    }
                );
        }
    }
}
