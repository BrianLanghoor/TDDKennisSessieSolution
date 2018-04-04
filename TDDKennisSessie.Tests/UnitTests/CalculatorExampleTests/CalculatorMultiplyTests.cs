using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.TddExamples;

namespace TDDKennisSessie.Tests.UnitTests.CalculatorExampleTests
{
    [TestClass]
    public class CalculatorMultiplyTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void WhenMultiplingFiveByFiveThenTheResultShouldBeTwentyFive()
        {
            _calculator.Multiply(5, 5).Should().Be(25);
        }

        [TestMethod]
        public void WhenMultiplingTwoByFourThenTheResultShouldBeEight()
        {
            _calculator.Multiply(2, 4).Should().Be(8);
        }

        [TestMethod]
        public void WhenMultiplingMinusTwoByFourThenTheResultShouldBeMinusEight()
        {
            _calculator.Multiply(-2, 4).Should().Be(-8);
        }

        [TestMethod]
        public void WhenMultiplingMinusTwoByMinusSixThenTheResultShouldBeTwelve()
        {
            _calculator.Multiply(-2, -6).Should().Be(12);
        }

        [TestMethod]
        public void WhenMultiplingSevenByMinusThreeThenTheResultShouldBeMinusFourtheen()
        {
            _calculator.Multiply(7, -3).Should().Be(-21);
        }
    }
}