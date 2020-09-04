﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nominatim.NetCore.API.Geocoders;
using Nominatim.NetCore.API.Models;

namespace Nominatim.NetCore.API.Tests
{
    [TestClass]
    public class ForwardGeocoderTests
    {

        [TestMethod]
        public void TestSuccessfulForwardGeocode()
        {
            var x = new ForwardGeocoder(ApplicationName: "f1ana.Nominatim.API");

            var r = x.Geocode(new ForwardGeocodeRequest
            {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r.Wait();

            Assert.IsTrue(r.Result.Length > 0);
        }

        [TestMethod]
        public void TestSuccessfulReverseGeocodeBuilding()
        {
            var y = new ReverseGeocoder(ApplicationName: "f1ana.Nominatim.API");

            var r2 = y.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -77.0365298,
                Latitude = 38.8976763,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r2.Wait();

            Assert.IsTrue(r2.Result.PlaceID > 0);
        }


        [TestMethod]
        public void TestSuccessfulReverseGeocodeRoad()
        {
            var z = new ReverseGeocoder(ApplicationName: "f1ana.Nominatim.API");

            var r3 = z.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -58.7051622809683,
                Latitude = -34.440723129053,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r3.Wait();

            Assert.IsTrue((r3.Result.PlaceID > 0) && (r3.Result.Category == "highway") && (r3.Result.ClassType == "motorway"));
        }

    }
}
