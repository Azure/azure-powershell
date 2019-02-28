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

    /// <summary>
    /// Class ValidationBase.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IValidationDescription" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IValidationDescription" />
    public abstract class ValidationBase : IValidationDescription
    {
        #region Fields and Properties
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; }
        /// <summary>
        /// Gets the kind of the validation.
        /// </summary>
        /// <value>The kind of the validation.</value>
        public ValidationKind ValidationKind { get; }
        /// <summary>
        /// Gets the type of the validation.
        /// </summary>
        /// <value>The type of the validation.</value>
        public ValidationType ValidationType { get; }
        /// <summary>
        /// Gets the successful result.
        /// </summary>
        /// <value>The successful result.</value>
        protected IValidationResult SuccessfulResult { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBase" /> class.
        /// </summary>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="validationType">Type of the validation.</param>
        /// <param name="validationKind">Kind of the validation.</param>
        public ValidationBase(
            string validationName,
            ValidationType validationType,
            ValidationKind validationKind)
        {
            DisplayName = validationName;
            ValidationKind = validationKind;
            ValidationType = validationType;
            SuccessfulResult = ValidationResult.SuccessfullValidationResult(validationType, validationKind);
        }
        #endregion
    }
}
