using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations
{
    public interface IValidationResult
    {
        ValidationType Type { get; }
        ResultLevel Level { get; }
        List<int> Positions { get; }
        string Description { get; }
        Result Result { get; }
    }
}