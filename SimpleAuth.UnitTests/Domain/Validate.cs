using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuth.UnitTests.Domain;

internal static class Validate
{
    internal static IList<ValidationResult> ValidateEntity(object entity)
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(entity, null, null);
        Validator.TryValidateObject(entity, context, validationResults, true);
        return validationResults;
    }
}