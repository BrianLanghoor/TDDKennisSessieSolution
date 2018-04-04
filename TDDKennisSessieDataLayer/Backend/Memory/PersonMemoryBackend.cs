using System.Collections.Generic;
using System.Linq;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Memory
{
    public class PersonMemoryBackend: IPersonBackend
    {
        public List<Person> InternalPersons = new List<Person>();
        public List<Person> GetAllPersons()
        {
            return InternalPersons;
        }

        public Person GetPersonById(int id)
        {
            return InternalPersons.Single(x => x.Id == id);
        }

        public void CreatePerson(Person person)
        {
            InternalPersons.Add(person);
        }

        public void UpdatePerson(Person updatedPerson)
        {
            var index = InternalPersons.FindIndex(x => x.Id == updatedPerson.Id);
            InternalPersons[index] = updatedPerson;
        }

        public void DeletePerson(int id)
        {
            var personToDelete = InternalPersons.Single(x => x.Id == id);
            InternalPersons.Remove(personToDelete);
        }
    }
}