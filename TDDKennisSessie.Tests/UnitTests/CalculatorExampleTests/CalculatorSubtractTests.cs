using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.TddExamples;

namespace TDDKennisSessie.Tests.UnitTests.CalculatorExampleTests
{
    [TestClass]
    public class CalculatorSubtractTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void WhenSubtractingTwentyByTenTheResultShouldBeTen()
        {
            _calculator.Subtract(20, 10).Should().Be(10);
        }

        [TestMethod]
        public void WhenSubtractingEightBySixTheResultShouldBeTwo()
        {
            _calculator.Subtract(8, 6).Should().Be(2);
        }

        [TestMethod]
        public void WhenSubtractingNineByThirtheenTheResultShouldBeMinusFour()
        {
            _calculator.Subtract(9, 13).Should().Be(-4);
        }

        [TestMethod]
        public void WhenSubtractingMinusNineByThirtheenTheResultShouldBeMinusTwentyTwo()
        {
            _calculator.Subtract(-9, 13).Should().Be(-22);
        }

        [TestMethod]
        public void WhenSubtractingNineByMinusThirtheenTheResultShouldBeMinusTwentyTwo()
        {
            _calculator.Subtract(9, -13).Should().Be(22);
        }
    }
}