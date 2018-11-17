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

    public enum Result
    {
        Unavailable,
        Success,
        Fail
    }

    public enum ResultLevel
    {
        Error,
        Warning,
        Info
    }

    public enum ValidationType
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

    public enum ValidationKind
    {
        SystemValidation,
        NamespaceValidation
    }

    public class ValidationResult : IValidationResult
    {
        #region Fields and Properties
        public ValidationType Type { get; set; }
        public string Path { get; set; }
        public ResultLevel Level { get; set; }
        public string Description { get; set; }
        public List<int> Positions { get; set; }
        public Result Result { get; set; }
        #endregion

        #region Public methods
        public static IValidationResult SuccessfullValidationResult(ValidationType validationType)
        {
            return new ValidationResult
            {
                Type = validationType,
                Level = ResultLevel.Info,
                Result = Result.Success
            };
        }

        public static IValidationResult UnavailableValidation(ValidationType validationType, string description)
        {
            return new ValidationResult
            {
                Type = validationType,
                Level = ResultLevel.Warning,
                Result = Result.Unavailable,
                Description = description
            };
        }

        public static IValidationResult UnauthorizedAccessDir(IDirectoryInfo dir)
        {
            return new ValidationResult
            {
                Level = ResultLevel.Warning,
                Result = Result.Unavailable,
                Description = "The directory could not be validated because the user is not authorized to access it.",
                Path = dir.FullName
            };
        }

        #endregion
    }
}