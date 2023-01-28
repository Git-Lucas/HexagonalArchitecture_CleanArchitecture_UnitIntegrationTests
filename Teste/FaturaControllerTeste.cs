namespace Teste
{
    [TestClass]
    public class FaturaControllerTeste
    {
        [TestMethod]
        public async Task GetFaturaMemoria()
        {
            var transacaoData = new TransacaoDataMemory();
            var moedaData = new MoedaDataAPI();

            var faturaUseCase = new FaturaUseCase(transacaoData, moedaData);

            var faturaController = new FaturaController(faturaUseCase);
            var response = await faturaController.GetAsync("4321");
            var okObjectResult = response as OkObjectResult;

            Assert.IsNotNull(response as OkObjectResult);

            var total = (double)okObjectResult.Value;
            
            Assert.AreEqual(1200, total);
        }
    }
}
