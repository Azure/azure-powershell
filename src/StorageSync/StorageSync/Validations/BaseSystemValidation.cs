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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using Interfaces;

    /// <summary>
    /// Class SystemValidationBase.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.ValidationBase" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.ISystemValidation" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.ValidationBase" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.ISystemValidation" />
    public abstract class SystemValidationBase : ValidationBase, ISystemValidation
    {
        #region Fields and Properties
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        protected IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemValidationBase" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="validationType">Type of the validation.</param>
        public SystemValidationBase(
            IConfiguration configuration,
            string validationName,
            ValidationType validationType) : base(validationName, validationType, ValidationKind.SystemValidation)
        {
            Configuration = configuration;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Validates the using.
        /// </summary>
        /// <param name="commandRunner">The command runner.</param>
        /// <returns>IValidationResult.</returns>
        public IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner)
        {
            return DoValidateUsing(commandRunner);
        }

        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate using.
        /// </summary>
        /// <param name="commandRunner">The command runner.</param>
        /// <returns>IValidationResult.</returns>
        protected virtual IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            return SuccessfulResult;
        }
        #endregion
    }
}
