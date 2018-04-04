using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDKennisSessie.Tests.UnitTests
{
    [TestClass]
    public class FluentTestExamples
    {
        [TestMethod]
        public void StuffShouldExamples()
        {
            string.Empty.Should().NotBeNull();
            string.Empty.Should().HaveLength(0);
            ((object)null).Should().BeNull();
            "1234".Should().Be("1234");
            100.Should().NotBe(99);
            DateTime.Now.Should().BeAfter(new DateTime(1900, 1, 1));
            Colors.Red.Should().NotBe(Colors.Green);
            (-1).Should().BeLessThan(0);
            1.Should().BeGreaterThan(0);
        }
    }

    public enum Colors
    {
        Red,
        Green
    }
}
