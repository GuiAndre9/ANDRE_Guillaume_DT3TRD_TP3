using Newtonsoft.Json;
using System.Text.Json;

namespace ConsoleApp1
{
    public class API
    {
        public static async Task<Root> Requete(string constrequete)
        {
            var api = "5369a438fbd27caaeee463405bea57bb";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format("https://api.openweathermap.org/data/2.5/weather?{0}&units=metric&appid={1}",constrequete,api))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var e = await response.Content.ReadAsStringAsync();
                var objDeserial = JsonConvert.DeserializeObject<Root>(e);
                return objDeserial ?? throw new InvalidOperationException();
            }
        }
    }
}