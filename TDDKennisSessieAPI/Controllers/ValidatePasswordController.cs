using System.Web.Mvc;
using TDDKennisSessie.TddExamples;
using TDDKennisSessieAPI.Models;

namespace TDDKennisSessieAPI.Controllers
{
    public class ValidatePasswordController : Controller
    {
        private readonly PasswordValidator _passwordValidator;

        public ValidatePasswordController(PasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Password")]ValidatePasswordViewModel validatePasswordModel)
        {
            var validatedPassword = _passwordValidator.Validate(validatePasswordModel.Password);
            validatePasswordModel.ErrorMessages = validatedPassword.ErrorMessages;
            validatePasswordModel.IsValid = validatedPassword.IsValid;

            return View("Validate", validatePasswordModel);
        }
    }
}