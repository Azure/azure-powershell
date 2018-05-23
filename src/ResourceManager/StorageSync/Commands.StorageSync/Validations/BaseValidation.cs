namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;

    public abstract class BaseValidation : IValidationDescription
    {
        #region Fields and Properties
        public string DisplayName { get; }
        public ValidationKind ValidationKind { get; }
        public ValidationType ValidationType { get; }
        protected IValidationResult SuccessfulResult { get; }
        #endregion

        #region Constructors
        public BaseValidation(
            string validationName,
            ValidationType validationType,
            ValidationKind validationKind)
        {
            this.DisplayName = validationName;
            this.ValidationKind = validationKind;
            this.ValidationType = validationType;
            this.SuccessfulResult = ValidationResult.SuccessfullValidationResult(validationType);
        }
        #endregion
    }
}
