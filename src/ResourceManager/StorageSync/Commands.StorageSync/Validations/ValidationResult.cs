using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations
{
    using Interfaces;

    /// <summary>
    /// Validation Result enumeration
    /// </summary>
    public enum Result
    {
        Unavailable,
        Success,
        Fail
    }

    /// <summary>
    /// 
    /// </summary>
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
        public ValidationType Type { get; set; }
        public string Path { get; set; }
        public ResultLevel Level { get; set; }
        public string Description { get; set; }
        public List<int> Positions { get; set; }
        public Result Result { get; set; }

        internal static IValidationResult SuccessfullValidationResult(ValidationType validationType)
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
    }
}