using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TDDKennisSessie.Logic;
using TDDKennisSessieAPI.Models;

namespace TDDKennisSessieAPI.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonLogic _personLogic;

        public PersonsController(PersonLogic personLogic)
        {
            _personLogic = personLogic;
        }

        public ActionResult Index()
        {
            return View(GetAllPersons());
        }

        private List<PersonNameViewModel> GetAllPersons()
        {
            var persons = _personLogic.GetAllPersons();
            return persons.Select(x => new PersonNameViewModel {Id = x.Id, Name = x.Name}).ToList();
        }
    }
}