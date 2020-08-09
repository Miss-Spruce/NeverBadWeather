using System;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;
using NUnit.Framework;

namespace NeverBadWeather.UnitTest
{
    public class ClothingRecommendationServiceTest
    {

        [Test]
        public async Task TestHappyCase()
        {
            // arrange
            var testDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var testPeriod = new TimePeriod(testDate, testDate.AddHours(10));
            var testLocation = new Location(59, 10);

            var mockWeatherForecastService = new Mock<IWeatherForecastService>();
            var mockClothingRuleRepository = new Mock<IClothingRuleRepository>();

            mockClothingRuleRepository
                .Setup(crr => crr.GetRulesByUser(It.IsAny<Guid?>()))
                .ReturnsAsync(new[]
                {
                    new ClothingRule(-20, 10, null, "Bobledress"),
                    new ClothingRule(10, 20, null, "Bukse og genser"),
                    new ClothingRule(20, 40, null, "T-skjore og shorts"),
                });


            mockWeatherForecastService
                .Setup(fs => fs.GetAllPlaces())
                .Returns(new[] { new Place("", "", "", "Andeby", new Location(59.1f, 10.1f)), });

            mockWeatherForecastService
                .Setup(fs => fs.GetWeatherForecast(It.IsAny<Place>()))
                .ReturnsAsync(new WeatherForecast(new[] {
                    new TemperatureForecast(25,testDate.AddHours(2), testDate.AddHours(4)),
                }));

            // act
            var request = new ClothingRecommendationRequest(testPeriod, testLocation);
            var service = new ClothingRecommendationService(
                mockWeatherForecastService.Object,
                mockClothingRuleRepository.Object);
            var recommendation = await service.GetClothingRecommendation(request);

            // assert
            Assert.AreEqual("Andeby", recommendation.Place.Name);
            Assert.That(recommendation.Rules, Has.Exactly(1).Items);
            var rule = recommendation.Rules.First();
            Assert.AreEqual("T-skjore og shorts", rule.Clothes);
        }

        [Test]

        public async Task TestCreateOrUpdateRule()
        {
          //arrange
            var mockClothingRuleRepository = new Mock<IClothingRuleRepository>();
            var mockWeatherFcService = new Mock<IWeatherForecastService>();

            mockClothingRuleRepository.Setup(crr => crr.GetRulesByUser(It.IsAny<Guid?>()))
               .ReturnsAsync(new[]
               {
                    new ClothingRule(-20, 10, null, "Bobledress"),
                    new ClothingRule(10, 20, null, "Bukse og genser"),
                    new ClothingRule(20, 40, null, "kjole"),
               });

            mockClothingRuleRepository.Setup(crr => crr.Create(It.IsAny<ClothingRule>())).ReturnsAsync(1);

            mockClothingRuleRepository.Setup(crr => crr.Update(It.IsAny<ClothingRule>())).ReturnsAsync(0);

            //act

            var newClothingRule = new ClothingRule(18, 28, null, "Sommerkjole");
           // var newClothingRule2 = new ClothingRule(0, 7, null, "Pelskåpe");


            var service = new ClothingRecommendationService(mockWeatherFcService.Object, mockClothingRuleRepository.Object);

            var rowWasAffected = await service.CreateOrUpdateRule(newClothingRule);

            //assert
            Assert.AreEqual(true, rowWasAffected);
            mockClothingRuleRepository.Verify(crr => crr.Create(newClothingRule));
        }

        [Test]
        public async Task TestSadCase()
        {
            // arrange
            var testDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var testPeriod = new TimePeriod(testDate, testDate.AddHours(10));
            var testLocation = new Location(59, 10);

            var mockWeatherForecastService = new Mock<IWeatherForecastService>();
            var mockClothingRuleRepository = new Mock<IClothingRuleRepository>();

            mockClothingRuleRepository
                .Setup(crr => crr.GetRulesByUser(It.IsAny<Guid?>()))
                .ReturnsAsync(new[]
                {
                    new ClothingRule(-20, 10, null, "Bobledress"),
                    new ClothingRule(10, 20, null, "Bukse og genser"),
                    new ClothingRule(20, 40, null, "T-skjore og shorts"),
                });


            mockWeatherForecastService
                .Setup(fs => fs.GetAllPlaces())
                .Returns(new[] { new Place("", "", "", "Larvik", new Location(59.1f, 10.1f)), });

            mockWeatherForecastService
                .Setup(fs => fs.GetWeatherForecast(It.IsAny<Place>()))
                .ReturnsAsync(new WeatherForecast(new[] {
                    new TemperatureForecast(25,testDate.AddHours(2), testDate.AddHours(4)),
                }));

            // act
            var request = new ClothingRecommendationRequest(testPeriod, testLocation);
            var service = new ClothingRecommendationService(
                mockWeatherForecastService.Object,
                mockClothingRuleRepository.Object);
            var recommendation = await service.GetClothingRecommendation(request);

            // assert
            Assert.AreEqual("Larvik", recommendation.Place.Name);
            Assert.That(recommendation.Rules, Has.Exactly(1).Items);
            var rule = recommendation.Rules.First();
            Assert.AreEqual("T-skjore og shorts", rule.Clothes);
        }

    }
}