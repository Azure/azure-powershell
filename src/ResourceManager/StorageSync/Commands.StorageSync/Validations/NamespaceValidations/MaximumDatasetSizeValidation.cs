namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;

    public class MaximumDatasetSizeValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly long _maxDataSetSize;
        #endregion

        #region Constructors

        public MaximumDatasetSizeValidation(IConfiguration configuration) : base(configuration, "Dataset size limit", ValidationType.DatasetSize)
        {
            this._maxDataSetSize = configuration.MaximumDatasetSizeInBytes();
        }

        #endregion

        #region Private methods

        protected override IValidationResult DoValidate(INamespaceInfo namespaceInfo)
        {
            bool dataSetTooBig = namespaceInfo.TotalFileSizeInBytes > this._maxDataSetSize;
            if (dataSetTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Type = this.ValidationType,
                    Level = ResultLevel.Error,
                    Description = $"The dataset is too big. Maximum dataset size is {this._maxDataSetSize}.",
                    Path = namespaceInfo.Path 
                };
            }

            return this.SuccessfulResult;
        }

        #endregion
    }
}