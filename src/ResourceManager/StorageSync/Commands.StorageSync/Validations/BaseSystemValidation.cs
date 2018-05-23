namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using Interfaces;

    public abstract class BaseSystemValidation : BaseValidation, ISystemValidation
    {
        #region Fields and Properties
        protected IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public BaseSystemValidation(
            IConfiguration configuration,
            string validationName,
            ValidationType validationType) : base(validationName, validationType, ValidationKind.SystemValidation)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Public methods

        public IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner)
        {
            return this.DoValidateUsing(commandRunner);
        }

        #endregion

        #region Protected methods
        protected virtual IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            return this.SuccessfulResult;
        }
        #endregion
    }
}
