using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    public interface IOutputWriter
    {
        void Write(IValidationResult validationResult);
    }
}