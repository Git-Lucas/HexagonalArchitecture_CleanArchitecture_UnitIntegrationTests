namespace Teste
{
    [TestClass]
    public class TransacaoCartaoTeste
    {
        [TestMethod]
        public void CriarTransacao()
        {
            var transacao = new TransacaoCartao() {
                NumeroCartao = "2582",
                DescricaoCompra = "Mercado Livre",
                Moeda = Moeda.BRL,
                Valor = 500,
                DataCompra = DateTime.Parse("01/01/2023")
            };

            Assert.AreEqual("2582", transacao.NumeroCartao);
            Assert.AreEqual("Mercado Livre", transacao.DescricaoCompra);
            Assert.AreEqual(Moeda.BRL, transacao.Moeda);
            Assert.AreEqual(500, transacao.Valor);
            Assert.AreEqual(new DateTime(2023,01,01), transacao.DataCompra);
        }
    }
}
