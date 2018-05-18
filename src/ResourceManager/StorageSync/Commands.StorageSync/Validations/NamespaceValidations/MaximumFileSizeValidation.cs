namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumFileSizeValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly long _maxFileSizeInBytes;
        #endregion

        #region Constructors
        public MaximumFileSizeValidation(IConfiguration configuration): base(configuration, ValidationType.FileSize)
        {
            this._maxFileSizeInBytes = configuration.MaximumFileSizeInBytes();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            bool fileIsTooBig = node.Length > this._maxFileSizeInBytes;

            if (fileIsTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} is too big. Maximum allowed file size is {this._maxFileSizeInBytes} bytes",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = this.ValidationType

                };
            }

            return this.SuccessfulResult;
        }
        #endregion
    }
}