namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumPathLengthValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly int _maxPathLength;
        #endregion

        #region Constructors
        public MaximumPathLengthValidation(IConfiguration configuration) : base(configuration, ValidationType.PathLength)
        {
            this._maxPathLength = configuration.MaximumPathLength();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return Validate(node);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return Validate(node);
        }
        #endregion

        #region Private methods
        private IValidationResult Validate(INamedObjectInfo node)
        {
            AfsPath path = new AfsPath(node.FullName);
            int pathLength = path.Length();

            bool pathIsTooLong = pathLength > this._maxPathLength;
            if (pathIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} path's is too long. Maximum path length is {this._maxPathLength}.",
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