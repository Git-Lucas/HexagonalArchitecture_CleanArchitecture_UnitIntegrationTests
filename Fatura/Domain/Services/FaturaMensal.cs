using Fatura.Domain.Models;
using Fatura.Domain.Models.Enums;

namespace Fatura.Domain.Services
{
    public class FaturaMensal
    {
        private readonly List<TransacaoCartao> _transacoes;
        private readonly Dictionary<string, double> _moedas;

        public FaturaMensal(List<TransacaoCartao> transacoes, Dictionary<string, double> moedas)
        {
            _transacoes = transacoes;
            _moedas = moedas;
        }

        public double CalcularFatura()
        {
            double total = 0;

            foreach (TransacaoCartao t in _transacoes)
            {
                if (t.Moeda == Moeda.BRL)
                    total += t.Valor;
                if (t.Moeda == Moeda.USD)
                    //Função adicionada para evitar que o sistema quebre, com a API de Moedas fora do ar.
                    //Eventualmente, poderia ser feita uma API própria, para continuar calculando, caso a API
                    //de Moedas não esteja no ar
                    total += t.Valor * (_moedas.Count > 0 ? _moedas["USD"] : 1);
                if (t.Moeda == Moeda.EUR)
                    total += t.Valor * (_moedas.Count > 0 ? _moedas["EUR"] : 1);
            }

            return total;
        }
    }
}
