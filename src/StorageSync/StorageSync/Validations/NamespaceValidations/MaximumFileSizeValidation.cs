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
    /// Class MaximumFileSizeValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    public class MaximumFileSizeValidation : NamespaceValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The maximum file size in bytes
        /// </summary>
        private readonly long _maxFileSizeInBytes;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumFileSizeValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MaximumFileSizeValidation(IConfiguration configuration): base(configuration, "Files over the size limit", ValidationType.FileSize)
        {
            _maxFileSizeInBytes = configuration.MaximumFileSizeInBytes();
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            bool fileIsTooBig = node.Length > _maxFileSizeInBytes;

            if (fileIsTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} is too big. Maximum allowed file size is {_maxFileSizeInBytes} bytes",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType,
                    Kind = ValidationKind
                };
            }

            return SuccessfulResult;
        }
        #endregion
    }
}