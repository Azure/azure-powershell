namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FilenamesCharactersValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private bool[] _codePointBlackList;
        private int NumberOfCodePoints = 0x10FFFF + 1;
        #endregion

        #region Constructors
        public FilenamesCharactersValidation(
            IConfiguration configuration): base(
                configuration,
                "Unsupported characters validation",
                ValidationType.FilenameCharacters)
        {
            var whitelistOfCodePointRanges = configuration.WhitelistOfCodePointRanges().ToList();
            var blacklistOfCodePoints = new HashSet<int>(configuration.BlacklistOfCodePoints());

            this._codePointBlackList = new bool[this.NumberOfCodePoints];

            for (int i = 0; i < this.NumberOfCodePoints; ++i)
            {
                this._codePointBlackList[i] = blacklistOfCodePoints.Contains(i) || !whitelistOfCodePointRanges.Any(range => range.Includes(i));
            }
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo file)
        {
            return ValidateInternal(file, isDirectory: false);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            // skip validating volume root
            if (directoryInfo.Name == directoryInfo.FullName)
            {
                return this.SuccessfulResult;
            }

            return ValidateInternal(directoryInfo, isDirectory: true);
        }

        #endregion

        #region Private methods
        
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
                    codePoint >= this.NumberOfCodePoints || 
                    this._codePointBlackList[codePoint])
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
                    Type = this.ValidationType,
                    Description = description,
                    Positions = positions
                };
            }

            return this.SuccessfulResult;
        }

        #endregion

    }
}
