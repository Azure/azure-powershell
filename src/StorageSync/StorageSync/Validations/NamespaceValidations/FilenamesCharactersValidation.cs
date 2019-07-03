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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class FilenamesCharactersValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations.NamespaceValidationBase" />
    public class FilenamesCharactersValidation : NamespaceValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The code point black list
        /// </summary>
        private bool[] _codePointBlackList;
        /// <summary>
        /// The number of code points
        /// </summary>
        private int NumberOfCodePoints = 0x10FFFF + 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilenamesCharactersValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FilenamesCharactersValidation(
            IConfiguration configuration): base(
                configuration,
                "File/Directory names with unsupported characters",
                ValidationType.FilenameCharacters)
        {
            var whitelistOfCodePointRanges = configuration.WhitelistOfCodePointRanges().ToList();
            var blacklistOfCodePoints = new HashSet<int>(configuration.BlacklistOfCodePoints());

            _codePointBlackList = new bool[NumberOfCodePoints];

            for (int i = 0; i < NumberOfCodePoints; ++i)
            {
                _codePointBlackList[i] = blacklistOfCodePoints.Contains(i) || !whitelistOfCodePointRanges.Any(range => range.Includes(i));
            }
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(IFileInfo file)
        {
            return ValidateInternal(file, isDirectory: false);
        }

        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            // skip validating volume root
            if (directoryInfo.Name == directoryInfo.FullName)
            {
                return SuccessfulResult;
            }

            return ValidateInternal(directoryInfo, isDirectory: true);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Validates the internal.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="isDirectory">if set to <c>true</c> [is directory].</param>
        /// <returns>IValidationResult.</returns>
        private IValidationResult ValidateInternal (INamedObjectInfo node, bool isDirectory)
        {
            string name = node.Name;
            List<int> positions = new List<int>();

            for (int i = 0, codepointIndex = 0; i < name.Length; ++i, ++codepointIndex)
            {
                int codePoint;

                if (char.IsSurrogatePair(name, i))
                {
                    codePoint = char.ConvertToUtf32(name, i);
                    i += 1;
                }
                else
                {
                    codePoint = name[i];
                }

                if (codePoint < 0 || 
                    codePoint >= NumberOfCodePoints || 
                    _codePointBlackList[codePoint])
                {
                    // adding +1 so that positions are 1-based
                    // to make them more human friendly
                    positions.Add(codepointIndex + 1);
                }
            }

            if (positions.Count > 0)
            {
                string itemLabel = isDirectory ? "Directory" : "File";
                string description = $"{itemLabel} {node.Name} has an unsupported character in position";
                if (positions.Count > 1)
                {
                    description += "s";
                }
                description += " ";
                description += String.Join(", ", positions);
                description += ".";

                return new ValidationResult
                {
                    Result = Result.Fail,
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType,
                    Kind = ValidationKind,
                    Description = description,
                    Positions = positions
                };
            }

            return SuccessfulResult;
        }

        #endregion

    }
}
