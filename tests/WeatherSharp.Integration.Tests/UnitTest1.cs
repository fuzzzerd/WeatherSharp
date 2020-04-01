using System;
using System.Threading.Tasks;
using Xunit;

namespace WeatherSharp.Integration.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var ws = new WeatherService();

            var point = await ws.GetPointAsync(double.Parse("41.903935"), double.Parse("-87.690010"));

            Assert.NotNull(point);
        }
    }
}
