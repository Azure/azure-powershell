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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Models
{
    using Interfaces;
    using Validations;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.StorageSync.Properties;

    /// <summary>
    /// Class PSValidationResult.
    /// </summary>
    public class PSValidationResult
    {
        #region Fields and Properties
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public PSValidationKind Kind { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PSValidationType Type { get; set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public PSResultLevel Level { get; set; }
        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        public List<int> Positions { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSValidationResult" /> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public PSValidationResult(IValidationResult result)
        {
            Kind = Convert(result.Kind);
            Type = Convert(result.Type);
            Level = Convert(result.Level);
            Positions = result.Positions != null ? new List<int>(result.Positions) : null;
            Description = result.Description;
            Path = result.Path;
        }

        #endregion

        #region Public methods
        #endregion

        #region Protected methods
        #endregion

        #region Private methods
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>PSValidationType.</returns>
        /// <exception cref="ArgumentException"></exception>
        private PSValidationType Convert(ValidationType value)
        {
            switch (value)
            {
                case ValidationType.DatasetSize:
                    return PSValidationType.DatasetSize;
                case ValidationType.Filename:
                    return PSValidationType.Filename;
                case ValidationType.FilenameCharacters:
                    return PSValidationType.FilenameCharacters;
                case ValidationType.FilenameLength:
                    return PSValidationType.FilenameLength;
                case ValidationType.FileSize:
                    return PSValidationType.FileSize;
                case ValidationType.FileSystem:
                    return PSValidationType.FileSystem;
                case ValidationType.NodeDepth:
                    return PSValidationType.NodeDepth;
                case ValidationType.OsVersion:
                    return PSValidationType.OsVersion;
                case ValidationType.PathLength:
                    return PSValidationType.PathLength;
                default:
                    throw new ArgumentException(string.Format(StorageSyncResources.UnsupportedErrorFormat, value.GetType().Name, value));
            }
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>PSResultLevel.</returns>
        /// <exception cref="ArgumentException"></exception>
        private PSResultLevel Convert(ResultLevel value)
        {
            switch (value)
            {
                case ResultLevel.Error:
                    return PSResultLevel.Error;
                case ResultLevel.Info:
                    return PSResultLevel.Info;
                case ResultLevel.Warning:
                    return PSResultLevel.Warning;
                default:
                    throw new ArgumentException(string.Format(StorageSyncResources.UnsupportedErrorFormat, value.GetType().Name, value));
            }
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>PSValidationKind.</returns>
        /// <exception cref="ArgumentException"></exception>
        private PSValidationKind Convert(ValidationKind value)
        {
            switch (value)
            {
                case ValidationKind.SystemValidation:
                    return PSValidationKind.SystemValidation;
                case ValidationKind.NamespaceValidation:
                    return PSValidationKind.NamespaceValidation;
                default:
                    throw new ArgumentException(string.Format(StorageSyncResources.UnsupportedErrorFormat, value.GetType().Name, value));
            }
        }

        #endregion
    }
}
