using Fatura.Domain.Data;
using Newtonsoft.Json;

namespace Fatura.Infra.Data
{
    public class MoedaDataAPI : IMoedaData
    {
        static HttpClient httpClient = new() { BaseAddress = new Uri("https://localhost:7087") };

        public async Task<Dictionary<string, double>> GetMoedasAsync()
        {
            var result = new Dictionary<string, double>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("/moedas");

                if (response is not null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }
    }
}
