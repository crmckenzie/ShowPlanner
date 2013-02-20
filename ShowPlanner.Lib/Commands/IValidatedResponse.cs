using System.Collections.Generic;
using Simple.Validation;

namespace ShowPlanner.Commands
{
    public interface IValidatedResponse
    {
        IEnumerable<ValidationResult> ValidationResults { get; set; } 
    }
}