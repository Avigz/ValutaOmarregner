using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValutaOmregner;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValutaOmregner.Tests
{
    [TestClass()]
    public class OmregnTests
    {
        [TestMethod()]
        public void TilSvenskeKronerTest()
        {
            double expectedResult = 1.420252805;
            double actualResult = Omregn.TilSvenskeKroner(1);

            Assert.AreEqual(Math.Round(expectedResult, 4), Math.Round(actualResult,4));
        }

        [TestMethod()]
        public void TilDanskeKronerTest()
        {
            double expectedResult = 1;
            double actualResult = Omregn.TilDanskeKroner(1.420252805);

            Assert.AreEqual(Math.Round(expectedResult, 4), Math.Round(actualResult,4));

        }

        [TestMethod()]
        public void TilDanskeKronerTestFejl()
        {
            double expectedResult = 1;
            double actualResult = Omregn.TilDanskeKroner(1.420252805);

            Assert.AreNotEqual(expectedResult, actualResult);

        }


    }
}