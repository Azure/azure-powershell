namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InvalidFilenameValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly HashSet<string> _invalidFileNames;
        #endregion

        #region Constructors

        public InvalidFilenameValidation(IConfiguration configuration) : base(configuration, ValidationType.Filename)
        {
            this._invalidFileNames = new HashSet<string>(configuration.InvalidFileNames(), StringComparer.OrdinalIgnoreCase);
        }

        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return Validate(node.Name, node.FullName);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return Validate(node.Name, node.FullName);
        }
        #endregion

        #region Private methods

        private IValidationResult Validate(string name, string path)
        {
            if (this._invalidFileNames.Contains(name))
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"The name {name} is not allowed.",
                    Level = ResultLevel.Error,
                    Path = path,
                    Type = this.ValidationType
                };
            }

            return this.SuccessfulResult;
        }

        #endregion
    }
}