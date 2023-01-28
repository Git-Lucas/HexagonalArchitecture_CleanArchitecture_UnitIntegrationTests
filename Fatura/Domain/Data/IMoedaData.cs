namespace Fatura.Domain.Data
{
    public interface IMoedaData
    {
        //Como minha API apresenta os dados com o padrão: chave e valor, armazeno no domínio da minha
        //aplicação como Dictionary<nomeMoeda, valorMoeda>
        Task<Dictionary<string, double>> GetMoedasAsync();
    }
}
