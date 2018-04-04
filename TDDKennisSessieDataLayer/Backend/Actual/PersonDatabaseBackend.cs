using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Actual
{
    public class PersonDatabaseBackend : IPersonBackend
    {
        private readonly DataContext _db;

        public PersonDatabaseBackend()
        {
            _db = new DataContext();
        }
        public List<Person> GetAllPersons()
        {
            return _db.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _db.Persons.Single(x => x.Id == id);
        }

        public void CreatePerson(Person person)
        {
            _db.Persons.Add(person);
            SaveChanges();
        }

        public void UpdatePerson(Person updatedPerson)
        {
            _db.Entry(updatedPerson).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var personToRemove = _db.Persons.Single(x => x.Id == id);
            _db.Persons.Remove(personToRemove);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}