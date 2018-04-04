using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessie.Models;
using TDDKennisSessieDataLayer.Backend.Memory;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.PersonTests
{
    [TestClass]
    public class CreatePersonTests
    {
        private PersonMemoryBackend _memoryBackend;
        private PersonLogic _personLogic;

        [TestInitialize]
        public void Initialize()
        {
            _memoryBackend = new PersonMemoryBackend();
            _personLogic = new PersonLogic(_memoryBackend);
        }

        [TestMethod]
        public void WhenNoPersonsExistAndWhenAnPersonIsCreatedTheNumberOfPersonsShouldBeOne()
        {
            _personLogic.CreatePerson(new PersonModel());
            _memoryBackend.InternalPersons.Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenOnePersonExistAndWhenAnPersonIsCreatedTheNumberOfPersonsShouldBeTwo()
        {
            _memoryBackend.InternalPersons.Add(new Person());
            _personLogic.CreatePerson(new PersonModel());
            _memoryBackend.InternalPersons.Count.Should().Be(2);
        }

        [TestMethod]
        public void WhenCreatingAPersonTheFirstNameShouldBeStored()
        {
            _personLogic.CreatePerson(new PersonModel {FirstName = "Brian"});
            _memoryBackend.InternalPersons.First().FirstName.Should().Be("Brian");
        }

        [TestMethod]
        public void WhenCreatingAPersonTheInsertionNameShouldBeStored()
        {
            _personLogic.CreatePerson(new PersonModel { InsertionName = "van" });
            _memoryBackend.InternalPersons.First().InsertionName.Should().Be("van");
        }

        [TestMethod]
        public void WhenCreatingAPersonTheLastNameShouldBeStored()
        {
            _personLogic.CreatePerson(new PersonModel { LastName = "Langhoor" });
            _memoryBackend.InternalPersons.First().LastName.Should().Be("Langhoor");
        }
    }
}