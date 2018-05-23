namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilenamesCharactersValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private bool[] _characterTable;
        #endregion

        #region Constructors
        public FilenamesCharactersValidation(
            IConfiguration configuration): base(
                configuration,
                "Unsupported characters validation",
                ValidationType.FilenameCharacters)
        {
            IList<Configuration.CodePointRange> blacklistOfCodePointRanges = configuration.BlacklistOfCodePointRanges().ToList();
            HashSet<int> blacklistOfCodePoints = new HashSet<int>(configuration.BlacklistOfCodePoints());

            int characterTableSize = 1 << 8 * sizeof(char);
            this._characterTable = new bool[characterTableSize];

            for (int i = 0; i < characterTableSize; ++i)
            {
                char aChar = (char)i;
                this._characterTable[i] = Char.IsHighSurrogate(aChar) ||
                    blacklistOfCodePointRanges.Any(range => range.Includes(aChar)) ||
                    blacklistOfCodePoints.Contains(aChar);
            }
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo file)
        {
            return ValidateInternal(file);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            // skip validating volume root
            if (directoryInfo.Name == directoryInfo.FullName)
            {
                return this.SuccessfulResult;
            }

            return ValidateInternal(directoryInfo);
        }

        #endregion

        #region Private methods
        
        private IValidationResult ValidateInternal (INamedObjectInfo node)
        {
            string name = node.Name;
            List<int> positions = new List<int>();
            for (int i = 0; i < name.Length; ++i)
            {
                if (IsBlacklisted(name[i]))
                {
                    positions.Add(i);
                }
            }

            if (positions.Count > 0)
            {
                string description = $"File {node.Name} has an unsupported character in position";
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

        private bool IsBlacklisted(char aChar)
        {
            return this._characterTable[aChar];
        }

        #endregion

    }
}
