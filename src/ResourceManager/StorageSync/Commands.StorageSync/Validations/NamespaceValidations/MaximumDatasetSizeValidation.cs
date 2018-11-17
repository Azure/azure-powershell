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

    public class MaximumDatasetSizeValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly long _maxDataSetSize;
        #endregion

        #region Constructors

        public MaximumDatasetSizeValidation(IConfiguration configuration) : base(configuration, "Namespace size limit", ValidationType.DatasetSize)
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