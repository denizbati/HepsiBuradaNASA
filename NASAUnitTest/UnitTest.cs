using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NASAUnitTest
{
    [TestClass]
    public class UnitTest
    {
        static List<string> coordinate = new List<string>();
        static List<string> rotate = new List<string>();
        string outputForData;

        [TestMethod]
        public void NasaCorrectCoordinateTest() // test
        {
            coordinate = new List<string>() { "1", "2", "N" };
            rotate = new List<string>() { "L", "M", "L", "M", "L", "M", "L", "M", "M" };

             outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("1 3 N", outputForData);

        }
        [TestMethod]
        public void NasaCorrectCoordinateTest2()
        {
            coordinate = new List<string>() { "3", "3","E" };
            rotate = new List<string>() { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" };
            outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("5 1 E", outputForData);
        }

        [TestMethod]
        //coordinate kısmı boşalırsa
        public void NasaCorrectCoordinateTest4()
        {
            coordinate = new List<string>() { };
            rotate = new List<string>() { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" };
            outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("5 1 E", outputForData);
        }
        [TestMethod]
        // rota girişi uyapılmadıysa
        public void NasaCorrectCoordinateTest5()
        {
            coordinate = new List<string>() { "3", "3", "E" };
            rotate = new List<string>() { };
            outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("5 1 E", outputForData);
        }
        [TestMethod]
        //ROTASYON kısmında yanlış girdi olursa
        public void NasaCorrectCoordinateTest6()
        {
            coordinate = new List<string>() { "3", "3", "E" };
            rotate = new List<string>() { "1", "M", "R", "M", "M", "R", "M", "R", "R", "M" };
            outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("5 1 E", outputForData);
        }
        [TestMethod]
        //coordinate kısmında yanlış girdi olursa
        public void NasaCorrectCoordinateTest7()
        {
            coordinate = new List<string>() { "3", "3", "5" };
            rotate = new List<string>() { "1", "M", "R", "M", "M", "R", "M", "R", "R", "M" };
            outputForData = HB_NASA.Program.plaetauCoordinateUnitTest(rotate, coordinate);

            Assert.AreEqual("5 1 E", outputForData);
        }
    }
}
