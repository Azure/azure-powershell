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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class InvalidFilenameValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    public class InvalidFilenameValidation : NamespaceValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The invalid file names
        /// </summary>
        private readonly HashSet<string> _invalidFileNames;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFilenameValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public InvalidFilenameValidation(IConfiguration configuration) : base(configuration, "Files with prohibited names", ValidationType.Filename)
        {
            _invalidFileNames = new HashSet<string>(configuration.InvalidFileNames(), StringComparer.OrdinalIgnoreCase);
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
            return Validate(node.Name, node.FullName);
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return Validate(node.Name, node.FullName);
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Validates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="path">The path.</param>
        /// <returns>IValidationResult.</returns>
        private IValidationResult Validate(string name, string path)
        {
            if (_invalidFileNames.Contains(name))
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"The name {name} is not allowed.",
                    Level = ResultLevel.Error,
                    Path = path,
                    Type = ValidationType,
                    Kind = ValidationKind
                };
            }

            return SuccessfulResult;
        }

        #endregion
    }
}