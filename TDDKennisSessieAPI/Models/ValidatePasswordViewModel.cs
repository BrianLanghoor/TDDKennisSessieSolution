using System.Collections.Generic;

namespace TDDKennisSessieAPI.Models
{
    public class ValidatePasswordViewModel
    {
        public string Password { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsValid { get; set; }
    }
}