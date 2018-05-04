namespace AFSEvaluationTool.Validations.SystemValidations
{
    public interface ISystemValidation
    {
        IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner);
    }
}