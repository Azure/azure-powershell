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

    public enum PSValidationType
    {
        FilenameCharacters,
        Filename,
        FilenameLength,
        FileSize,
        PathLength,
        NodeDepth,
        DatasetSize,
        FileSystem,
        OsVersion
    }

    public enum PSResultLevel
    {
        Error,
        Warning,
        Info
    }

    public class PSValidationResult
    {
        #region Fields and Properties
        public PSValidationType Type { get; set; }
        public PSResultLevel Level { get; set; }
        public List<int> Positions { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        #endregion

        #region Constructors

        public PSValidationResult(IValidationResult result)
        {
            this.Type = this.Convert(result.Type);
            this.Level = this.Convert(result.Level);
            this.Positions = result.Positions != null ? new List<int>(result.Positions) : null;
            this.Description = result.Description;
            this.Path = result.Path;
        }

        #endregion

        #region Public methods
        #endregion

        #region Protected methods
        #endregion

        #region Private methods
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
                    throw new ArgumentException($"{value.GetType().Name} value {value} is unsupported");
            }
        }

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
                    throw new ArgumentException($"{value.GetType().Name} value {value} is unsupported");
            }
        }
        #endregion
    }
}
