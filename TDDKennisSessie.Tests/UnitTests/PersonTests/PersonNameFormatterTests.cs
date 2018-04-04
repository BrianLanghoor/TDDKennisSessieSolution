using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic.Calculators;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.PersonTests
{
    [TestClass]
    public class PersonNameFormatterTests
    {
        private readonly PersonNameFormatter _nameFormatter = new PersonNameFormatter();

        [TestMethod]
        public void WhenFormattingTheNameJanVanDoornTheResultShouldCorrespond()
        {
            var formattedName = _nameFormatter.FormatPersonName(new Person { FirstName = "Jan", InsertionName = "van", LastName = "Doorn" });
            formattedName.Should().Be("Doorn, van (J.D.)");
        }

        [TestMethod]
        public void WhenFormattingTheNameHarryVanDeHeuvelTheResultShouldCorrespond()
        {
            var formattedName = _nameFormatter.FormatPersonName(new Person { FirstName = "Harry", InsertionName = "van de", LastName = "Heuvel" });
            formattedName.Should().Be("Heuvel, van de (H.H.)");
        }

        [TestMethod]
        public void WhenFormattingTheNameHarryVanDenHeuvelTheResultShouldCorrespond()
        {
            var formattedName = _nameFormatter.FormatPersonName(new Person { FirstName = "Harry", InsertionName = "van den", LastName = "Heuvel" });
            formattedName.Should().Be("Heuvel, van den (H.H.)");
        }

        [TestMethod]
        public void WhenFormattingTheNameBrianLanghoorTheResultShouldCorrespond()
        {
            var formattedName = _nameFormatter.FormatPersonName(new Person { FirstName = "Brian", InsertionName = "", LastName = "Langhoor" });
            formattedName.Should().Be("Langhoor, (B.L.)");
        }

        [TestMethod]
        public void WhenFormattingTheNameJanPeterBalkenendeTheResultShouldCorrespond()
        {
            var formattedName = _nameFormatter.FormatPersonName(new Person { FirstName = "Jan-Peter", InsertionName = "", LastName = "Balkenende" });
            formattedName.Should().Be("Balkenende, (J.P.B.)");
        }
    }
}