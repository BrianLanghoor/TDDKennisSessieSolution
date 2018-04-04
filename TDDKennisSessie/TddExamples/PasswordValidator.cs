using System.Collections.Generic;
using System.Linq;
using TDDKennisSessie.Models;

namespace TDDKennisSessie.TddExamples
{
    public class PasswordValidator
    {
        public ValidatedPassword Validate(string password)
        {
            var validatedPassword = new ValidatedPassword {ErrorMessages = new List<string>()};

            CheckPasswordForLenght(password, validatedPassword);
            CheckPasswordForNumbers(password, validatedPassword);
            CheckPasswordForCapitalLetter(password, validatedPassword);
            CheckPasswordForLowerCaseLetter(password, validatedPassword);

            SetPasswordValidWhenNoErrorsExist(validatedPassword);

            return validatedPassword;
        }

        private static void CheckPasswordForLowerCaseLetter(string password, ValidatedPassword validatedPassword)
        {
            if (!password.Any(char.IsLower))
            {
                validatedPassword.ErrorMessages.Add("Password must at least contain one lowercase letter.");
            }
        }

        private static void CheckPasswordForCapitalLetter(string password, ValidatedPassword validatedPassword)
        {
            if (!password.Any(char.IsUpper))
            {
                validatedPassword.ErrorMessages.Add("Password must at least contain one capital letter.");
            }
        }

        private static void CheckPasswordForNumbers(string password, ValidatedPassword validatedPassword)
        {
            if (!password.Any(char.IsDigit))
            {
                validatedPassword.ErrorMessages.Add("Password must at least contain one number.");
            }
        }

        private static void SetPasswordValidWhenNoErrorsExist(ValidatedPassword validatedPassword)
        {
            if (validatedPassword.ErrorMessages.Count == 0)
            {
                validatedPassword.IsValid = true;
            }
        }

        private static void CheckPasswordForLenght(string password, ValidatedPassword validatedPassword)
        {
            if (password.Length < 8 || password.Length > 15)
            {
                validatedPassword.ErrorMessages.Add("Password must contain between 8-15 characters.");
            }
        }
    }
}