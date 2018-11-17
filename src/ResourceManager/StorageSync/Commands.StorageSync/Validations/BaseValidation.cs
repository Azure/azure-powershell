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
