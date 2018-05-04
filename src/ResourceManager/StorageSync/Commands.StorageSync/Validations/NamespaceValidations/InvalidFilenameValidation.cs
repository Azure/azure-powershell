using System.Linq;

namespace AFSEvaluationTool.Validations.NamespaceValidations
{
    public class InvalidFilenameValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public InvalidFilenameValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo node)
        {
            return Validate(node.Name, node.FullName);
        }

        public IValidationResult Validate(IDirectoryInfo node)
        {
            return Validate(node.Name, node.FullName);
        }

        private IValidationResult Validate(string name, string path)
        {
            if (_configuration.InvalidFileNames().Contains(name))
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"The name {name} is not allowed.",
                    Level = ResultLevel.Error,
                    Path = path,
                    Type = ValidationType.Filename
                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.Filename);
        }
    }
}