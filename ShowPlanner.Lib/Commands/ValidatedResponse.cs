using System.Collections.Generic;
using Simple.Validation;

namespace Sextant.Common.Commands
{
    public class ValidatedResponse : IValidatedResponse
    {
        public IEnumerable<ValidationResult> ValidationResults { get; set; }

        public ValidatedResponse()
        {
            ValidationResults = new ValidationResult[]{};
        }
    }
}