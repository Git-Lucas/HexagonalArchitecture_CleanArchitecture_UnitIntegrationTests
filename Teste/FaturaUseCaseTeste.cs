namespace Teste
{
    [TestClass]
    public class FaturaUseCaseTeste
    {
        [TestMethod]
        public async Task CalcularFatura()
        {
            //Implementação do Mock, para a instanciação de uma Interface, armazenando num objeto
            var transacaoData = new Mock<ITransacaoData>();
            //É possível mockar todos os retornos dos seus métodos, atentando a:
            //Métodos assíncronos: method().Result
            //Métodos com parâmetros: It.IsAny<type>()
            //Documentação: https://github.com/Moq/moq4/wiki/Quickstart
            transacaoData.Setup(x => x.GetTransacoesAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()).Result)
                         .Returns(new List<TransacaoCartao>() {
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
                                     DataCompra = DateTime.Parse("20/01/2023") }
                        });

            var moedaData = new Mock<IMoedaData>();
            moedaData.Setup(x => x.GetMoedasAsync().Result)
                     .Returns(new Dictionary<string, double> { { "USD", 3 } });

            var faturaService = new FaturaUseCase(transacaoData.Object, moedaData.Object);
            //Mesmo com o número do cartão errado, o objeto "transacoes", que o considera como parâmetro,
            //na função de retorno, já está com o retorno definido
            var total = await faturaService.CalcularFaturaAsync("5464");

            Assert.AreEqual(2750, total);
        }

        [TestMethod]
        public async Task CalcularFaturaMemoria()
        {
            var transacaoData = new TransacaoDataMemory();
            var moedaData = new MoedaDataAPI();

            var fatureUseCase = new FaturaUseCase(transacaoData, moedaData);

            var total = await fatureUseCase.CalcularFaturaAsync("4321");

            Assert.AreEqual(1200, total);
        }

        [TestMethod]
        public async Task CalcularFaturaSqlite()
        {
            var transacaoData = new TransacaoDataSqlite(new EfSqliteAdapter());
            var moedaData = new MoedaDataAPI();

            var faturaUseCase = new FaturaUseCase(transacaoData, moedaData);

            var total = await faturaUseCase.CalcularFaturaAsync("4321");

            Assert.AreEqual(1200, total);
        }
    }
}
