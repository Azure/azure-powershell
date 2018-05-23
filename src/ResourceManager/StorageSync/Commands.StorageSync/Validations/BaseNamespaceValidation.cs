namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;

    public class BaseNamespaceValidation : BaseValidation, INamespaceValidation
    {
        #region Fields and Properties
        protected IConfiguration Configuration { get;  }
        #endregion

        #region Constructors
        public BaseNamespaceValidation(
            IConfiguration configuration,
            string validationName,
            ValidationType validationType): base(validationName, validationType, ValidationKind.NamespaceValidation)
        {
            this.Configuration = configuration;
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
    }
}
