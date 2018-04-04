using System.Collections.Generic;

namespace TDDKennisSessie.Models
{
    public class ValidatedPassword
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}