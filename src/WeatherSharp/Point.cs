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
        public string cwa { get; set; }
        public string ForecastOffice { get; set; }
        public int GridX { get; set; }
        public int GridY { get; set; }
    }
}
