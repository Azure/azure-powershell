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
    /// Class NamespaceValidationBase.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.ValidationBase" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamespaceValidation" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.ValidationBase" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamespaceValidation" />
    public class NamespaceValidationBase : ValidationBase, INamespaceValidation
    {
        #region Fields and Properties
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        protected IConfiguration Configuration { get;  }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceValidationBase" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="validationType">Type of the validation.</param>
        public NamespaceValidationBase(
            IConfiguration configuration,
            string validationName,
            ValidationType validationType): base(validationName, validationType, ValidationKind.NamespaceValidation)
        {
            Configuration = configuration;
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Validates the specified file information.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>IValidationResult.</returns>
        public IValidationResult Validate(IFileInfo fileInfo)
        {
            return DoValidate(fileInfo);
        }

        /// <summary>
        /// Validates the specified directory information.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns>IValidationResult.</returns>
        public IValidationResult Validate(IDirectoryInfo directoryInfo)
        {
            return DoValidate(directoryInfo);
        }

        /// <summary>
        /// Validates the specified namespace information.
        /// </summary>
        /// <param name="namespaceInfo">The namespace information.</param>
        /// <returns>IValidationResult.</returns>
        public IValidationResult Validate(INamespaceInfo namespaceInfo)
        {
            return DoValidate(namespaceInfo);
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>IValidationResult.</returns>
        protected virtual IValidationResult DoValidate(IFileInfo file)
        {
            return SuccessfulResult;
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns>IValidationResult.</returns>
        protected virtual IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            return SuccessfulResult;
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="namespaceInfo">The namespace information.</param>
        /// <returns>IValidationResult.</returns>
        protected virtual IValidationResult DoValidate(INamespaceInfo namespaceInfo)
        {
            return SuccessfulResult;
        }
        #endregion
    }
}
