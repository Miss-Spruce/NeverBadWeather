using NUnit.Framework;
using System;
using System.Globalization;

namespace NeverBadWeather.DomainModel.UnitTest
{
    public class LocationTest
    {
        [Test]
        public void TestIsWithinInside()
        {
            // arrange
            var corner1 = new Location(0, 0);
            var corner2 = new Location(1, 1);
            var location = new Location(0.5f, 0.5f);

            // act
            var isWithin = location.IsWithin(corner1, corner2);

            // assert
            Assert.IsTrue(isWithin);
        }


        [Test]
        public void TestIsWithinInsideFalse()
        {
            // arrange
            var corner1 = new Location(0, 0);
            var corner2 = new Location(1, 1);
            var location = new Location(1f, 2f);

            // act
            var isWithin = location.IsWithin(corner1, corner2);

            // assert
            Assert.IsFalse(isWithin);
        }

        [Test]
        public void TestToFloat()
        {
            var longit = "51.23000";

            float converted = Convert.ToSingle(longit, CultureInfo.InvariantCulture.NumberFormat);

            Assert.AreEqual(51.23000, converted, 0.0005f);
        }

        [Test]
        public void TestGetDistanceFrom()
        {
            Location destination = new Location(40.53562f, 53.47384f);
            Location loca = new Location(42.99553f, 41.99553f);

            var deltaLat = loca.Latitude - destination.Latitude;
            var deltaLon = loca.Longitude - destination.Longitude;

            var answer = 11.73894193120487d;

            Assert.AreEqual(Math.Sqrt(deltaLon * deltaLon + deltaLat * deltaLat), answer, 0.000002f);

        }

        [Test]
        public void  TestCreateWithDelta()
        {
            Location loca = new Location(2.12345f, 1.24245f);

            float deltaLat = 1.42512f;
            float deltaLon = 2.42545f;

            var first = 2.12345f + 1.42512f;
            var second = 1.24245f + 2.42545f;

            Assert.AreEqual(first, Convert.ToSingle(loca.Latitude) + deltaLat);
            Assert.AreEqual(second, Convert.ToSingle(loca.Longitude) + deltaLon);
        }
    }
}