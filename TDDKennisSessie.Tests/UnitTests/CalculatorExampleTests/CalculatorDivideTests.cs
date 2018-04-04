using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.TddExamples;

namespace TDDKennisSessie.Tests.UnitTests.CalculatorExampleTests
{
    [TestClass]
    public class CalculatorDivideTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void DividingNineByThreeShouldResultInThree()
        {
            var result = _calculator.Divide(9, 3);
            result.Should().Be(3);
        }

        [TestMethod]
        public void DividingTenByTwoShouldResultInFive()
        {
            var result = _calculator.Divide(10, 2);
            result.Should().Be(5);
        }


        [TestMethod]
        public void DividingTwelveByMinusTwoShouldResultInMinusSix()
        {
            var result = _calculator.Divide(12, -2);
            result.Should().Be(-6);
        }

        [TestMethod]
        public void DividingMinusFiftheenByThreeShouldResultInMinusFive()
        {
            var result = _calculator.Divide(-15, 3);
            result.Should().Be(-5);
        }

        [TestMethod]
        public void DividingMinusFiftheenByMinusThreeShouldResultInFive()
        {
            var result = _calculator.Divide(-15, -3);
            result.Should().Be(5);
        }

        [TestMethod]
        public void DividingZeroByThreeShouldResultInZero()
        {
            var result = _calculator.Divide(0, 3);
            result.Should().Be(0);
        }


        [TestMethod]
        public void DividingElevenByTwoShouldResultInFivePointFive()
        {
            var result = _calculator.Divide(11, 2);
            result.Should().Be(5.5);
        }

        [TestMethod]
        public void DividingByZeroShouldNotBePossible()
        {
            Action action = () => _calculator.Divide(12, 0);
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Specified argument was out of the range of valid values.Parameter name: Cannot divide by zero");
        }
    }
}