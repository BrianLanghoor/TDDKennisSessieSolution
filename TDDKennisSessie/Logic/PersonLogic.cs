using System.Collections.Generic;
using System.Linq;
using TDDKennisSessie.Logic.Calculators;
using TDDKennisSessie.Models;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Logic
{
    public class PersonLogic
    {
        private readonly IPersonBackend _personBackend;
        private readonly PersonNameFormatter _nameFormatter = new PersonNameFormatter();

        public PersonLogic(IPersonBackend memoryPersonBackend)
        {
            _personBackend = memoryPersonBackend;
        }

        public List<PersonNameModel> GetAllPersons()
        {
            return _personBackend.GetAllPersons()
                .Select(person =>
                    new PersonNameModel
                    {
                        Id = person.Id,
                        Name = _nameFormatter.FormatPersonName(person)
                    }).ToList();
        }

        public PersonModel GetPersonById(int id)
        {
            var person = _personBackend.GetPersonById(id);
            return new PersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                InsertionName = person.InsertionName,
                LastName = person.LastName
            };
        }

        public void CreatePerson(PersonModel person)
        {
            _personBackend.CreatePerson(new Person
            {
                FirstName = person.FirstName,
                InsertionName = person.InsertionName,
                LastName = person.LastName
            });
        }

        public void UpdatePerson(PersonModel personModel)
        {
            _personBackend.UpdatePerson(new Person
            {
                Id = personModel.Id,
                FirstName = personModel.FirstName,
                InsertionName = personModel.InsertionName,
                LastName = personModel.LastName
            });
        }

        public void DeletePerson(int id)
        {
            _personBackend.DeletePerson(id);
        }
    }
}