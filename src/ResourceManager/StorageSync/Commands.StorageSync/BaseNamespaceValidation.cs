using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class BaseNamespaceValidation : INamespaceValidation
    {
        #region Fields and Properties
        protected IConfiguration Configuration { get;  }
        protected ValidationType ValidationType { get; }
        protected IValidationResult SuccessfulResult { get; }
        #endregion

        #region Constructors
        public BaseNamespaceValidation(
            IConfiguration configuration,
            ValidationType validationType)
        {
            this.Configuration = configuration;
            this.ValidationType = validationType;
            this.SuccessfulResult = ValidationResult.SuccessfullValidationResult(validationType);
        }

        #endregion

        #region Public methods
        public IValidationResult Validate(IFileInfo fileInfo)
        {
            return this.DoValidate(fileInfo);
        }

        public IValidationResult Validate(IDirectoryInfo directoryInfo)
        {
            return this.DoValidate(directoryInfo);
        }

        public IValidationResult Validate(INamespaceInfo namespaceInfo)
        {
            return this.DoValidate(namespaceInfo);
        }
        #endregion

        #region Protected methods
        protected virtual IValidationResult DoValidate(IFileInfo file)
        {
            return this.SuccessfulResult;
        }

        protected virtual IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            return this.SuccessfulResult;
        }

        protected virtual IValidationResult DoValidate(INamespaceInfo namespaceInfo)
        {
            return this.SuccessfulResult;
        }
        #endregion

        #region Private methods
        #endregion
    }
}
