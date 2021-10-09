using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NASAUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void NasaCorrectCoordinateTest() // test
        {
            List<string> coordinate = new List<string>() { "1", "2", "N" };
            List<string> rotate = new List<string>() { "L", "M", "L", "M", "L", "M", "L", "M", "M" };

            string outputForData = HB_NASA.Program.plaetauCoordinate(rotate,coordinate);

            Assert.AreEqual("1 3 N", outputForData);



        }
    }
}
