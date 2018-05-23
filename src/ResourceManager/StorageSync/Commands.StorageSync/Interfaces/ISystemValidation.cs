namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface ISystemValidation
    {
        IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner);
    }
}