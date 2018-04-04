using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieDataLayer.Backend.Memory;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.PersonTests
{
    [TestClass]
    public class GetPersonByIdTests
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
        public void WhenThereOnePersonExistsGetPersonByIdShouldReturnThatId()
        {
            _memoryBackend.InternalPersons.Add(new Person {Id = 1, FirstName = "Brian", LastName = "Langhoor"});
            _personLogic.GetPersonById(1).Id.Should().Be(1);
        }

        [TestMethod]
        public void WhenThereOnePersonExistsGetPersonByIdShouldReturnThatFirstName()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1, FirstName = "Brian", LastName = "Langhoor" });
            _personLogic.GetPersonById(1).FirstName.Should().Be("Brian");
        }

        [TestMethod]
        public void WhenThereOnePersonExistsGetPersonByIdShouldReturnThatLastName()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1, FirstName = "Brian", LastName = "Langhoor" });
            _personLogic.GetPersonById(1).LastName.Should().Be("Langhoor");
        }

        [TestMethod]
        public void WhenThereIsNoPersonGetPersonByIdShouldResultInAnError()
        {
            Action action = () => _personLogic.GetPersonById(1);
            action.Should().Throw<InvalidOperationException>();
        }
    }
}