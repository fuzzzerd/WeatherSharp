using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherSharp
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly string _userAgent;
        public WeatherService(HttpClient client)
        {
            _client = client;
            _userAgent = "WeatherSharp";

            // setup some defaults
            _client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
        }

        public async Task<Point> GetPointAsync(double latitude, double longitude)
        {
            var httpRequest = new HttpRequestMessage();

            httpRequest.RequestUri = new Uri($"https://api.weather.gov/points/{latitude},{longitude}");

            var response = await _client.SendAsync(httpRequest);
            var responseJson = await response.Content.ReadAsStringAsync();

            //https://stu.dev/a-look-at-jsondocument/
            var jdoc = JsonDocument.Parse(responseJson);
            var properties = jdoc.RootElement.GetProperty("properties");

            var point = JsonSerializer.Deserialize<Point>(properties.GetRawText());

            return point;
        }
    }
}
