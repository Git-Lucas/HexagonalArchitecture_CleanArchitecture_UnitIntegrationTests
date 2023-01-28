namespace Teste
{
    [TestClass]
    public class TransacaoDataTeste
    {
        [TestMethod]
        public async Task GetTransacoesMemoria()
        {
            var transacaoData = new TransacaoDataMemory();

            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            var transacoes = await transacaoData.GetTransacoesAsync("1234", mesAtual, anoAtual);

            //Inicio na memória com 4 transações: 2 no mês atual, e 2 no mês seguinte ao atual
            Assert.AreEqual(2, transacoes.Count());
        }

        [TestMethod]
        public async Task GetTransacoesSqlite()
        {
            var transacaoDataSqlite = new TransacaoDataSqlite(new EfSqliteAdapter());

            var mesAtual = DateTime.Now.Month;
            var anoAtual = DateTime.Now.Year;
            var transacoes = await transacaoDataSqlite.GetTransacoesAsync("1234", mesAtual, anoAtual);

            Assert.AreEqual(2, transacoes.Count);
        }
    }
}
