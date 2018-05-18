namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumFilenameLengthValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly int _maxFilenameLength;
        #endregion

        #region Constructors
        public MaximumFilenameLengthValidation(IConfiguration configuration): base(configuration, ValidationType.FilenameLength)
        {
            this._maxFilenameLength = configuration.MaximumFilenameLength();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return Validate((INamedObjectInfo)node);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return Validate((INamedObjectInfo)node);
        }
        #endregion

        #region Private methods

        private IValidationResult Validate(INamedObjectInfo node)
        {
            bool filenameIsTooLong = node.Name.Length > this._maxFilenameLength;

            if (filenameIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Filename {node.Name} is too long. Max length is {this._maxFilenameLength}",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = this.ValidationType

                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.FilenameLength);
        }

        #endregion
    }
}