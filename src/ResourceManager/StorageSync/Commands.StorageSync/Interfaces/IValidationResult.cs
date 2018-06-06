namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using System.Collections.Generic;
    using Validations;

    public interface IValidationResult
    {
        ValidationType Type { get; }
        ResultLevel Level { get; }
        List<int> Positions { get; }
        string Description { get; }
        Result Result { get; }
        string Path { get; }
    }
}