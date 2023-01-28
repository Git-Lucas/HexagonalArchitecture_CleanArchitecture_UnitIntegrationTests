using Fatura.Domain.Models;

namespace Fatura.Domain.Data
{
    public interface ITransacaoData
    {
        //O objetivo do projeto seria uma API Fatura, que apenas calcula o valor total mensal a partir de
        //dados externos de banco de dados, e valor atual de uma moeda via API. Por isso, não existem os
        //métodos de criação, atualização ou exclusão de dados
        Task<List<TransacaoCartao>> GetTransacoesAsync(string numeroCartao, int mes, int ano);
    }
}
