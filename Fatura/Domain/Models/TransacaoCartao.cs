using Fatura.Domain.Models.Enums;

namespace Fatura.Domain.Models
{
    public class TransacaoCartao
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; } = null!;
        public string DescricaoCompra { get; set; } = string.Empty;
        public double Valor { get; set; }
        public Moeda Moeda { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
