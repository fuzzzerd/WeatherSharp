using System;
using System.Threading.Tasks;

namespace WeatherSharp
{
    public interface IWeatherService
    {
        Task<Point> GetPointAsync(double latitude, double longitude);
    }
}
