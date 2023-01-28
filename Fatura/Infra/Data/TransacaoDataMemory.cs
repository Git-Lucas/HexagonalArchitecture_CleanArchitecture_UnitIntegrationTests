using Fatura.Domain.Data;
using Fatura.Domain.Models;
using Fatura.Domain.Models.Enums;

namespace Fatura.Infra.Data
{
    public class TransacaoDataMemory : ITransacaoData
    {
        public List<TransacaoCartao> Transacoes { get; set; } = new(){
                new () { NumeroCartao = "1234",
                         Valor = 1200,
                         Moeda = Moeda.BRL,
                         DataCompra = DateTime.Parse($"01/{DateTime.Now.Month}/{DateTime.Now.Year}") },
                new () { NumeroCartao = "1234",
                         Valor = 400,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse($"05/{DateTime.Now.Month}/{DateTime.Now.Year}") },
                new () { NumeroCartao = "4321",
                         Valor = 400,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse($"05/{DateTime.Now.Month}/{DateTime.Now.Year}") },
                new () { NumeroCartao = "1234",
                         Valor = 200,
                         Moeda = Moeda.BRL,
                         DataCompra = DateTime.Parse($"10/{DateTime.Now.Month+1}/{DateTime.Now.Year}") },
                new () { NumeroCartao = "1234",
                         Valor = 50,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse($"20/{DateTime.Now.Month+1}/{DateTime.Now.Year}") },
                new () { NumeroCartao = "4321",
                         Valor = 50,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse($"20/{DateTime.Now.Month+1}/{DateTime.Now.Year}") }
            };

        public async Task<List<TransacaoCartao>> GetTransacoesAsync(string numeroCartao, int mes, int ano)
        {
            return Transacoes.Where(x => x.NumeroCartao == numeroCartao && 
                                         x.DataCompra.Month == mes && 
                                         x.DataCompra.Year == ano).ToList();
        }
    }
}
