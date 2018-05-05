namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumFileSizeValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public MaximumFileSizeValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo node)
        {
            long maxFileSizeInBytes = _configuration.MaximumFileSizeInBytes();
            bool fileIsTooBig = node.Length > maxFileSizeInBytes;

            if (fileIsTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} is too big. Maximum allowed file size is {maxFileSizeInBytes} bytes",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType.FileSize

                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.FileSize);
        }

        public IValidationResult Validate(IDirectoryInfo node)
        {
            return ValidationResult.SuccessfullValidationResult(ValidationType.FileSize);
        }
    }
}