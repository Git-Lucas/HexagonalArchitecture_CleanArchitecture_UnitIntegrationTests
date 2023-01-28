using Fatura.Domain.Data;
using Fatura.Domain.Models;
using Fatura.Infra.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Infra.Data
{
    public class TransacaoDataSqlite : ITransacaoData
    {
        private readonly EfSqliteAdapter _context;

        public TransacaoDataSqlite(EfSqliteAdapter context)
        {
            _context = context;
        }

        public async Task<List<TransacaoCartao>> GetTransacoesAsync(string numeroCartao, int mes, int ano)
        {
            var result = await _context.Transacoes.Where(x => x.NumeroCartao == numeroCartao &&
                                                              x.DataCompra.Month == mes &&
                                                              x.DataCompra.Year == ano).ToListAsync();

            return result;
        }
    }
}
