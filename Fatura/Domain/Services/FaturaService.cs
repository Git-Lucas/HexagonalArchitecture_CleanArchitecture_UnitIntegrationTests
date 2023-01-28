namespace Fatura.Domain.Services
{
    public class FaturaService
    {
        public int Mes { get; } = DateTime.Now.Month;
        public int Ano { get; } = DateTime.Now.Year;
    }
}
