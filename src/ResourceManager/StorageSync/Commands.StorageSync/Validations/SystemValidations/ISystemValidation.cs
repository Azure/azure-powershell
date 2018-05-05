namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    public interface ISystemValidation
    {
        IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner);
    }
}