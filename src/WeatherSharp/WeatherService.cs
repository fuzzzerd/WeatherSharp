using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherSharp
{
    public class WeatherService : IWeatherService
    {
        public async Task<Point> GetPointAsync(double latitude, double longitude)
        {
            var requestUri = $"https://api.weather.gov/points/{latitude},{longitude}";
            var client = new HttpClient();
            var httpRequest = new HttpRequestMessage();
            
            httpRequest.RequestUri = new Uri(requestUri);
            httpRequest.Headers.Add("User-Agent", "WeatherSharp");

            var response = await client.SendAsync(httpRequest);
            var responseJson = await response.Content.ReadAsStringAsync();

            //https://stu.dev/a-look-at-jsondocument/
            var jdoc = JsonDocument.Parse(responseJson);
            var properties = jdoc.RootElement.GetProperty("properties");

            var point = JsonSerializer.Deserialize<Point>(properties.GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return point;
        }
    }
}
