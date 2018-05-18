namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public interface INamespaceValidation
    {
        IValidationResult Validate(IFileInfo node);
        IValidationResult Validate(IDirectoryInfo node);
        IValidationResult Validate(INamespaceInfo namespaceInfo);
    }
}