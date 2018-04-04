using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.TddExamples;

namespace TDDKennisSessie.Tests.UnitTests.CalculatorExampleTests
{
    [TestClass]
    public class CalculatorAddTests
    {
        [TestMethod]
        public void WhenAddingTheNumberTwoAndFiveTheResultShouldBeSeven()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(2, 5);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void WhenAddingTheNumberTwelveAndSixTheResultShouldBeEighteen()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(12, 6);

            //Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void WhenAddingTheNumberThreeAndMinus9TheResultShouldBeMinusSix()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(3, -9);

            //Assert
            Assert.AreEqual(-6, result);
        }

        [TestMethod]
        public void WhenAddingTheNumberMinusTenAnElevenTheResultShouldBeOne()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(-10, 11);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WhenAddingTheNumberMinusFiveAnMinusFourTheResultShouldBeOne()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(-5, -4);

            //Assert
            Assert.AreEqual(-9, result);
        }
    }
}
