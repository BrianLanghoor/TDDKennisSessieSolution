using System;
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
    public class UpdatePersonTests
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
        public void WhenUpdatingAPersonTheFirstNameShouldBeChanged()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1 });
            _personLogic.UpdatePerson(new PersonModel { Id = 1, FirstName = "Brian"});
            _memoryBackend.InternalPersons.First().FirstName.Should().Be("Brian");
        }

        [TestMethod]
        public void WhenUpdatingAPersonTheInsertionNameShouldBeChanged()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1 });
            _personLogic.UpdatePerson(new PersonModel { Id = 1, InsertionName = "van" });
            _memoryBackend.InternalPersons.First().InsertionName.Should().Be("van");
        }

        [TestMethod]
        public void WhenUpdatingAPersonTheLastNameShouldBeChanged()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1 });
            _personLogic.UpdatePerson(new PersonModel { Id = 1, LastName = "Langhoor" });
            _memoryBackend.InternalPersons.First().LastName.Should().Be("Langhoor");
        }

        [TestMethod]
        public void WhenThePersonToUpdateDoesNotExistThenTheExceptionShouldBeInvalid()
        {
            Action action = () => _personLogic.UpdatePerson(new PersonModel { Id = 1, LastName = "Langhoor" });
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}