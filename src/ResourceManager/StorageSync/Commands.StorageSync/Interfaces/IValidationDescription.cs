namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;

    public interface IValidationDescription
    {
        string DisplayName { get; }
        ValidationKind ValidationKind { get; }
        ValidationType ValidationType { get; }
    }
}
