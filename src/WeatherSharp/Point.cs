using System;
using System.Text.Json.Serialization;

namespace WeatherSharp
{
    public class Point
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("@type")]
        public string @Type { get; set; }

        [JsonPropertyName("cwa")]
        public string Cwa { get; set; }

        [JsonPropertyName("forecastOffice")]
        public string ForecastOffice { get; set; }

        [JsonPropertyName("gridX")]
        public int GridX { get; set; }

        [JsonPropertyName("gridY")]
        public int GridY { get; set; }
    }
}
