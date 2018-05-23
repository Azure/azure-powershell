namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface INamespaceValidation
    {
        IValidationResult Validate(IFileInfo node);
        IValidationResult Validate(IDirectoryInfo node);
        IValidationResult Validate(INamespaceInfo namespaceInfo);
    }
}