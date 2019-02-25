// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;

    /// <summary>
    /// Class MaximumDatasetSizeValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    public class MaximumDatasetSizeValidation : NamespaceValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The maximum data set size
        /// </summary>
        private readonly long _maxDataSetSize;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumDatasetSizeValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MaximumDatasetSizeValidation(IConfiguration configuration) : base(configuration, "Namespace size limit", ValidationType.DatasetSize)
        {
            _maxDataSetSize = configuration.MaximumDatasetSizeInBytes();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="namespaceInfo">The namespace information.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(INamespaceInfo namespaceInfo)
        {
            bool dataSetTooBig = namespaceInfo.TotalFileSizeInBytes > _maxDataSetSize;
            if (dataSetTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Type = ValidationType,
                    Kind = ValidationKind,
                    Level = ResultLevel.Error,
                    Description = $"The dataset is too big. Maximum dataset size is {_maxDataSetSize}.",
                    Path = namespaceInfo.Path 
                };
            }

            return SuccessfulResult;
        }

        #endregion
    }
}