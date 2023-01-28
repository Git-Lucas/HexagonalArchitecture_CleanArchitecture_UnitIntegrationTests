namespace Teste
{
    [TestClass]
    public class FaturaMensalTeste
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public FaturaMensalTeste()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
            _baseUrl = "https://localhost:7087";
        }

        [TestMethod]
        public void CalcularFatura()
        {
            var transacoes = new List<TransacaoCartao>() {
                new () { NumeroCartao = "1234",
                         Valor = 1200,
                         Moeda = Moeda.BRL,
                         DataCompra = DateTime.Parse("01/01/2023") },
                new () { NumeroCartao = "1234",
                         Valor = 400,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse("05/01/2023") },
                new () { NumeroCartao = "1234",
                         Valor = 200,
                         Moeda = Moeda.BRL,
                         DataCompra = DateTime.Parse("10/01/2023") },
                new () { NumeroCartao = "1234",
                         Valor = 50,
                         Moeda = Moeda.USD,
                         DataCompra = DateTime.Parse("20/01/2023") },
                new () { NumeroCartao = "2585",
                         Valor = 50,
                         Moeda = Moeda.BRL,
                         DataCompra = DateTime.Parse("25/05/2023") }
            };

            var moedas = new Dictionary<string, double>
            {
                { "USD", 3}
            };

            var fatura = new FaturaMensal(transacoes, moedas);
            //O filtro para cálculo das transações apenas do mês é aplicado na obtenção dos dados.
            //Então, nesse caso, o teste é realmente de cálculo dos valores, considerando o valor em real 
            //das demais moedas
            var total = fatura.CalcularFatura();

            Assert.AreEqual(2800, total);
        }

        [TestMethod]
        public async Task CalcularFaturaMemoria()
        {
            var transacaoData = new TransacaoDataMemory();
            var transacoes = await transacaoData.GetTransacoesAsync("1234",
                                                                    DateTime.Now.Month,
                                                                    DateTime.Now.Year);
            var response = await _httpClient.GetAsync($"{_baseUrl}/moedas");
            var resultString = await response.Content.ReadAsStringAsync();
            var moedas = JsonConvert.DeserializeObject<Dictionary<string, double>>(resultString);

            var faturaMensal = new FaturaMensal(transacoes, moedas);
            var total = faturaMensal.CalcularFatura();

            Assert.AreEqual(2400, total);
        }

        [TestMethod]
        public async Task CalcularFaturaSqlite()
        {
            var transacaoData = new TransacaoDataSqlite(new EfSqliteAdapter());
            var moedaData = new MoedaDataAPI();

            var transacoes = await transacaoData.GetTransacoesAsync("1234", 
                                                                    DateTime.Now.Month, 
                                                                    DateTime.Now.Year);
            var moedas = await moedaData.GetMoedasAsync();

            var faturaMensal = new FaturaMensal(transacoes, moedas);
            var total = faturaMensal.CalcularFatura();

            Assert.AreEqual(2400, total);
        }
    }
}
