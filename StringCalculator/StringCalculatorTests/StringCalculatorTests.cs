using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestClass()]
    public class StringCalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            StringCalculator s = new StringCalculator();
            Assert.AreEqual(s.Add(""), 0);
            Assert.AreEqual(s.Add("5"), 5);
            Assert.AreEqual(s.Add("5,5"), 10);
            Assert.AreEqual(s.Add("5\n5"), 10);
            Assert.AreEqual(s.Add("5,5,5,5,5,5,5,5,5,5"), 50);
            Assert.AreEqual(s.Add("1,2\n3,4\n5\n6"), 21);
            Assert.AreEqual(s.Add("//;\n1;2"), 3);
            Assert.AreEqual(s.Add("//;\n1;2,3,4\n5;6"), 21);
            Assert.AreEqual(s.Add("//[ttt][%%][tyler]\n100,5ttt200%%4tyler3"), 312);
            Assert.AreEqual(s.Add("//[*]][%]\n1*2%3"), 6);
            Assert.AreEqual(s.Add("//[t][%][y]\n100,5t200%4y3"), 312);
            Assert.AreEqual(s.Add("1001,2"), 2);
            Assert.AreEqual(s.Add("1000,2"), 1002);

            try
            {
                s.Add("1001,-2");
                Assert.Fail();
            }
            catch (Exception)
            {

            }

        }
    }
}