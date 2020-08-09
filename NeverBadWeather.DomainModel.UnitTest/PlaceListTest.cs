using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    public class PlaceListTest
    {
        [Test]
        public void TestGetClosestPlace()
        {

        //arrange
        var min = new Location(-1,-1);
        var max = new Location(1,1);
        var bestPlace = new Location(1,1);

        //act
        var isItHere = bestPlace.IsWithin(min,max);

        //assert
        Assert.IsTrue(isItHere); 
    }
        }
    }

