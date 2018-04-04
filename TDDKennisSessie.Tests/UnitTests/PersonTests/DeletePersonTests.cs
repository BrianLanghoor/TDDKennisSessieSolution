using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieDataLayer.Backend.Memory;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.PersonTests
{
    [TestClass]
    public class DeletePersonTests
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
        public void WhenAPersonExistAndIDeleteThatPersonNoPersonsShouldBeStored()
        {
            _memoryBackend.InternalPersons.Add(new Person {Id = 1});
            _personLogic.DeletePerson(1);
            _memoryBackend.InternalPersons.Count.Should().Be(0);
        }

        [TestMethod]
        public void WhenMultiplePersonsExistAndIDeleteAPersonOnlyThatPersonShouldBeRemoved()
        {
            _memoryBackend.InternalPersons.Add(new Person { Id = 1 });
            _memoryBackend.InternalPersons.Add(new Person { Id = 2 });
            _personLogic.DeletePerson(1);
            _memoryBackend.InternalPersons.Single().Id.Should().Be(2);
        }

        [TestMethod]
        public void WhenNoPersonExistAndIDeleteAPersonThenTheActionShouldBeInvalid()
        {
            Action action = () => _personLogic.DeletePerson(1);
            action.Should().Throw<InvalidOperationException>();
        }
    }
}