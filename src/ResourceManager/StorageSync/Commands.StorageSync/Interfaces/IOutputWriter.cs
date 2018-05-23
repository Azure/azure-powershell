namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface IOutputWriter
    {
        void Write(IValidationResult validationResult);
    }
}