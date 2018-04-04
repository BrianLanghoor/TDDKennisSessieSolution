using System.Linq;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Logic.Calculators
{
    public class PersonNameFormatter
    {
        public string FormatPersonName(Person person)
        {
            var formattedName = person.LastName;

            formattedName = AddInsertionName(person, formattedName);
            formattedName = AddInitialsFromFirstNames(person, formattedName);
            formattedName = formattedName + person.LastName.First() + ".)";

            return formattedName;
        }

        private static string AddInitialsFromFirstNames(Person person, string formattedLastName)
        {
            var splittedFirstName = person.FirstName.Split(" -".ToCharArray());
            formattedLastName = splittedFirstName.Aggregate(formattedLastName, (current, splitName) => current + splitName.ToUpper().First() + ".");
            return formattedLastName;
        }

        private static string AddInsertionName(Person person, string formattedLastNameAndInsertionName)
        {
            if (person.InsertionName.Length == 0)
            {
                formattedLastNameAndInsertionName = formattedLastNameAndInsertionName + ", (";
            }
            else
            {
                formattedLastNameAndInsertionName = formattedLastNameAndInsertionName + ", " + person.InsertionName + " (";
            }
            return formattedLastNameAndInsertionName;
        }
    }
}