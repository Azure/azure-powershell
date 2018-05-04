using AFSEvaluationTool.Validations;

namespace AFSEvaluationTool.OutputWriters
{
    public interface IOutputWriter
    {
        void Write(IValidationResult validationResult);
    }
}