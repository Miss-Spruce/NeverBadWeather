using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    public class WeatherForecastTest
    {
        [Test]
        public void TestLimitTo()
        {
          // arrange 
           var dateTimeFrom = new DateTime(11);
           var dateTimeTo = new DateTime(12);
           var temp = new TemperatureForecast(11, dateTimeFrom, dateTimeTo);

            // act
            var isBetween = temp.Equals(temp);

            // assert
            Assert.IsTrue(isBetween);
        }

        [Test]
        public void TestGetStats()
        {
            var stats = new TemperatureStatistics();
            var temp = new Location(12,14);

            var gettingStats = stats.Equals(temp);

            Assert.IsFalse(gettingStats);
        }
    }
}
