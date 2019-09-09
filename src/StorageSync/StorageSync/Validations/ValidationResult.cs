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
    using System;
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Enum Result
    /// </summary>
    public enum Result
    {
        /// <summary>
        /// The unavailable
        /// </summary>
        Unavailable,
        /// <summary>
        /// The success
        /// </summary>
        Success,
        /// <summary>
        /// The fail
        /// </summary>
        Fail
    }

    /// <summary>
    /// Enum ResultLevel
    /// </summary>
    public enum ResultLevel
    {
        /// <summary>
        /// The error
        /// </summary>
        Error,
        /// <summary>
        /// The warning
        /// </summary>
        Warning,
        /// <summary>
        /// The information
        /// </summary>
        Info
    }

    /// <summary>
    /// Enum ValidationType
    /// </summary>
    public enum ValidationType
    {
        /// <summary>
        /// The filename characters
        /// </summary>
        FilenameCharacters,
        /// <summary>
        /// The filename
        /// </summary>
        Filename,
        /// <summary>
        /// The filename length
        /// </summary>
        FilenameLength,
        /// <summary>
        /// The file size
        /// </summary>
        FileSize,
        /// <summary>
        /// The path length
        /// </summary>
        PathLength,
        /// <summary>
        /// The node depth
        /// </summary>
        NodeDepth,
        /// <summary>
        /// The dataset size
        /// </summary>
        DatasetSize,
        /// <summary>
        /// The file system
        /// </summary>
        FileSystem,
        /// <summary>
        /// The os version
        /// </summary>
        OsVersion
    }

    /// <summary>
    /// Enum ValidationKind
    /// </summary>
    public enum ValidationKind
    {
        /// <summary>
        /// The system validation
        /// </summary>
        SystemValidation,
        /// <summary>
        /// The namespace validation
        /// </summary>
        NamespaceValidation
    }

    /// <summary>
    /// Class ValidationResult.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IValidationResult" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IValidationResult" />
    public class ValidationResult : IValidationResult
    {
        #region Fields and Properties
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public ValidationKind Kind { get; set; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public ValidationType Type { get; set; }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        public ResultLevel Level { get; set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets the positions.
        /// </summary>
        /// <value>The positions.</value>
        public List<int> Positions { get; set; }
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public Result Result { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Successfulls the validation result.
        /// </summary>
        /// <param name="validationType">Type of the validation.</param>
        /// <param name="validationKind">Kind of the validation.</param>
        /// <returns>IValidationResult.</returns>
        public static IValidationResult SuccessfullValidationResult(ValidationType validationType, ValidationKind validationKind)
        {
            return new ValidationResult
            {
                Type = validationType,
                Kind = validationKind,
                Level = ResultLevel.Info,
                Result = Result.Success,
                Description = "Validation succeeded."
            };
        }

        /// <summary>
        /// Unavailables the validation.
        /// </summary>
        /// <param name="validationType">Type of the validation.</param>
        /// <param name="validationKind">Kind of the validation.</param>
        /// <param name="description">The description.</param>
        /// <returns>IValidationResult.</returns>
        public static IValidationResult UnavailableValidation(ValidationType validationType, ValidationKind validationKind, string description)
        {
            return new ValidationResult
            {
                Type = validationType,
                Kind = validationKind,
                Level = ResultLevel.Warning,
                Result = Result.Unavailable,
                Description = description
            };
        }

        /// <summary>
        /// Unauthorizeds the access dir.
        /// </summary>
        /// <param name="validationType">Type of the validation.</param>
        /// <param name="validationKind">Kind of the validation.</param>
        /// <param name="dir">The dir.</param>
        /// <returns>IValidationResult.</returns>
        public static IValidationResult UnauthorizedAccessDir(ValidationType validationType, ValidationKind validationKind, IDirectoryInfo dir)
        {
            return new ValidationResult
            {
                Type = validationType,
                Kind = validationKind,
                Level = ResultLevel.Warning,
                Result = Result.Unavailable,
                Description = "The directory could not be validated because the user is not authorized to access it.",
                Path = dir.FullName
            };
        }

        #endregion
    }
}