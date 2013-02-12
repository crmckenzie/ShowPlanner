using System.Collections.Generic;
using Simple.Validation;

namespace Sextant.Common.Commands
{
    public interface IValidatedResponse
    {
        IEnumerable<ValidationResult> ValidationResults { get; set; } 
    }
}