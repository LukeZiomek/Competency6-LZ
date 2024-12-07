using Competency5.Client;

namespace Competency5.Client.Tests
{
    [TestClass]
    public class InvestmentCalcTests
    {
        // ### Math tests ###

        [TestMethod]
        public void TestDefaults()
        {
            // Test: Principal 1000, Interest 25, Years 5, CMPYear 1
            // Calc result: 1000 * (1 + (25/100) / 1)^(1 * 5) = 3051.758
            // 3051.7578125 unrounded
            var expected = 3051.7578125;

            // The class
            var calculatorClass = new InvestmentCalc();

            // Setting vars to trigger Calc(), even though they are the default
            calculatorClass.Principal = 1000;
            calculatorClass.Interest = 25;
            calculatorClass.Years = 5;
            calculatorClass.CmpPerYear = 1;
            // Get result
            var actual = calculatorClass.FutureValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDefaultsRounded()
        {
            // Test: Principal 1000, Interest 25, Years 5, CMPYear 1
            // Calc result: 1000 * (1 + (25/100) / 1)^(1 * 5) = 3051.758
            // 3051.7578125 unrounded
            var expected = 3051.758; // I'm simply using the rounded value this time

            // Class
            var calculatorClass = new InvestmentCalc();

            // Setting vars to trigger Calc(), even though they are the default
            calculatorClass.Principal = 1000;
            calculatorClass.Interest = 25;
            calculatorClass.Years = 5;
            calculatorClass.CmpPerYear = 1;
            // Get result
            var actual = Math.Round(calculatorClass.FutureValue, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBiggerCmPerYear()
        {
            // Test: Principal 1000, Interest 25, Years 5, CMPYear 3
            // Calc result: 1000 * (1 + (25/100) / 3)^(3 * 5) = 3322.245
            // 3322.24452119422333227898 unrounded
            var expected = 3322.245;

            // Class
            var calculatorClass = new InvestmentCalc();

            // Setting vars to trigger Calc()
            calculatorClass.Principal = 1000;
            calculatorClass.Interest = 25;
            calculatorClass.Years = 5;
            calculatorClass.CmpPerYear = 3; // I now have a CmpPerYear of 3
            // Get result
            var actual = Math.Round(calculatorClass.FutureValue, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLargeValues()
        {
            // Test: Principal 250,000,000, Interest 50, Years 12, CMPYear 2
            // Calc result: 250000000 * (1 + (50/100) / 2)^(2 * 12) = 52939559203.394
            // 52939559203.39377119177015629248 unrounded
            var expected = 52939559203.394;

            // Class
            var calculatorClass = new InvestmentCalc();

            // Setting vars to trigger Calc()
            calculatorClass.Principal = 250000000;
            calculatorClass.Interest = 50;
            calculatorClass.Years = 12;
            calculatorClass.CmpPerYear = 2;
            // Get result
            var actual = Math.Round(calculatorClass.FutureValue, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ### Error tests ###

        [TestMethod]
        public void ExceptionWhenNegativeInterest()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception with a negative interest
            Assert.ThrowsException<Exception>(() => calculatorClass.Interest = -5);
        }

        [TestMethod]
        public void ExceptionWhenNegativePrincipal()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception with a negative principal
            Assert.ThrowsException<Exception>(() => calculatorClass.Principal = -1000);
        }

        [TestMethod]
        public void ExceptionWhenNegativeCmpPerYear()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception with a negative Compounds per year
            Assert.ThrowsException<Exception>(() => calculatorClass.CmpPerYear = -3);
        }

        [TestMethod]
        public void ExceptionWhenNegativeYears()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception with a negative ammount of years
            // This is the most ridiculous negative, as you cannot go back in time (yet)
            Assert.ThrowsException<Exception>(() => calculatorClass.Years = -5);
        }

        [TestMethod]
        public void YearsOutOfRangeErr()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception when years > 30
            Assert.ThrowsException<Exception>(() => calculatorClass.Years = 31);
        }

        [TestMethod]
        public void CmpPerYearOutOfRangeErr()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception when CmpPerYear > 24
            Assert.ThrowsException<Exception>(() => calculatorClass.CmpPerYear = 30);
        }

        [TestMethod]
        public void InterestOutOfRangeErr()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should throw an exception when Interest > 100%
            Assert.ThrowsException<Exception>(() => calculatorClass.Interest = 200);
        }

        [TestMethod]
        public void PrincipleOutOfRangeErr()
        {
            // Class
            var calculatorClass = new InvestmentCalc(25, 1000, 5, 3);

            // Should just throw an exception when Principal > max double
            Assert.ThrowsException<Exception>(() => calculatorClass.Principal = double.PositiveInfinity);
        }
    }
}