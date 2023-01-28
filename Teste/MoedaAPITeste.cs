namespace Teste
{
    [TestClass]
    public class MoedaAPITeste
    {
        private readonly HttpClient _httpClient;

        public MoedaAPITeste()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7087");
        }

        [TestMethod]
        public async Task GetMoedasTestServer()
        {
            var response = await _httpClient.GetAsync($"/moedas");
            var jsonString = await response.Content.ReadAsStringAsync();
            var moedas = JsonConvert.DeserializeObject<Dictionary<string,double>>(jsonString);

            Assert.AreEqual(3, moedas["USD"]);
        }

        [TestMethod]
        public async Task GetMoedasAPI()
        {
            var moedaDataAPI = new MoedaDataAPI();
            var moedas = await moedaDataAPI.GetMoedasAsync();

            Assert.AreEqual(3, moedas["USD"]);
        }
    }
}