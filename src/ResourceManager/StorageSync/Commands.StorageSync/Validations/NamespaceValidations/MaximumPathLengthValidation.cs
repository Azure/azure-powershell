namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;

    public class MaximumPathLengthValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly int _maxPathLength;
        #endregion

        #region Constructors
        public MaximumPathLengthValidation(IConfiguration configuration) : base(configuration, "Path length limit", ValidationType.PathLength)
        {
            this._maxPathLength = configuration.MaximumPathLength();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return ValidateInternal(node);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return ValidateInternal(node);
        }
        #endregion

        #region Private methods
        private IValidationResult ValidateInternal(INamedObjectInfo node)
        {
            AfsPath path = new AfsPath(node.FullName);
            int pathLength = path.Length;

            bool pathIsTooLong = pathLength > this._maxPathLength;
            if (pathIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Path length limit exceeded. Maximum length is {this._maxPathLength}.",
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