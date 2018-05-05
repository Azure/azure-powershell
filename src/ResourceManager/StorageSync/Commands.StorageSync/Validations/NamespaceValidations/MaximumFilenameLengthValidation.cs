namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumFilenameLengthValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public MaximumFilenameLengthValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo node)
        {
            return Validate((IFileSystemInfo) node);
        }

        public IValidationResult Validate(IDirectoryInfo node)
        {
            return Validate((IFileSystemInfo) node);
        }

        private IValidationResult Validate(IFileSystemInfo node)
        {
            int maxFilenameLength = _configuration.MaximumFilenameLength();
            bool filenameIsTooLong = node.Name.Length > maxFilenameLength;

            if (filenameIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Filename {node.Name} is too long. Max length is {maxFilenameLength}",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType.FilenameLength

                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.FilenameLength);
        }
    }
}