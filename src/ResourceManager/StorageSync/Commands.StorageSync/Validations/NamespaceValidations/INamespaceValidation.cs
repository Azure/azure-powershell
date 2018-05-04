namespace AFSEvaluationTool.Validations.NamespaceValidations
{
    public interface INamespaceValidation
    {
        IValidationResult Validate(IFileInfo node);
        IValidationResult Validate(IDirectoryInfo node);
    }
}