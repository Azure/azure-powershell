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
    /// Class MaximumPathLengthValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    public class MaximumPathLengthValidation : NamespaceValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The maximum path length
        /// </summary>
        private readonly int _maxPathLength;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MaximumPathLengthValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MaximumPathLengthValidation(IConfiguration configuration) : base(configuration, "Files/Directories over the path length limit", ValidationType.PathLength)
        {
            _maxPathLength = configuration.MaximumPathLength();
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
            return ValidateInternal(node);
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return ValidateInternal(node);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Validates the internal.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IValidationResult.</returns>
        private IValidationResult ValidateInternal(INamedObjectInfo node)
        {
            AfsPath path = new AfsPath(node.FullName);
            int pathLength = path.Length;

            bool pathIsTooLong = pathLength > _maxPathLength;
            if (pathIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Path length limit exceeded. Maximum length is {_maxPathLength}.",
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