using Fatura.Domain.Data;
using Fatura.Domain.Services;

namespace Fatura.Application
{
    //FaturaUseCase é um dos serviços de Fatura, que contém, a partir do Main da aplicação, na execução,
    //todos os dados necessários para realizar o processo de cálculo de fatura. No método, ele só espera o
    //número do cartão para a apresentação do valor em reais do total dele, após a conversão das moedas
    public class FaturaUseCase
    {
        private readonly ITransacaoData _transacaoData;
        private readonly IMoedaData _moedaData;

        public FaturaUseCase(ITransacaoData transacaoData, IMoedaData moedaData)
        {
            _transacaoData = transacaoData;
            _moedaData = moedaData;
        }

        public async Task<double> CalcularFaturaAsync(string numeroCartao)
        {
            var faturaService = new FaturaService();

            var moedas = await _moedaData.GetMoedasAsync();
            var transacoes = await _transacaoData.GetTransacoesAsync(numeroCartao, faturaService.Mes, faturaService.Ano);

            var fatura = new FaturaMensal(transacoes, moedas);

            return fatura.CalcularFatura();
        }
    }
}
