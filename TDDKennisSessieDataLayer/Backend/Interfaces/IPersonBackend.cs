using System.Collections.Generic;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Interfaces
{
    public interface IPersonBackend
    {
        List<Person> GetAllPersons();
        Person GetPersonById(int id);
        void CreatePerson(Person person);
        void UpdatePerson(Person updatedPerson);
        void DeletePerson(int id);
    }
}