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
        PSValidationType Type { get; set; }
        PSResultLevel Level { get; set; }
        List<int> Positions { get; set; }
        string Description { get; set; }
        #endregion

        #region Constructors

        public PSValidationResult(IValidationResult result)
        {
            this.Type = this.Convert(result.Type);
            this.Level = this.Convert(result.Level);
            this.Positions = new List<int>(result.Positions);
            this.Description = result.Description;
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
