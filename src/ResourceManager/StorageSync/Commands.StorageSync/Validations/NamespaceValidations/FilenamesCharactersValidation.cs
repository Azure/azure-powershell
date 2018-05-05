using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class FilenamesCharactersValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public FilenamesCharactersValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo file)
        {
            return Validate((IFileSystemInfo)file);
        }

        public IValidationResult Validate(IDirectoryInfo file)
        {
            return Validate((IFileSystemInfo)file);
        }

        private IValidationResult Validate (IFileSystemInfo node)
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

            if (positions.Count() > 0)
            {
                string description = $"File {node.Name} has an unsupported character in position";
                if (positions.Count() > 1)
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
                    Type = ValidationType.FilenameCharacters,
                    Description = description,
                    Positions = positions
                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.FilenameCharacters);
        }

        private bool IsBlacklisted(char aChar)
        {
            return 
                Char.IsHighSurrogate(aChar) ||
                _configuration.BlacklistOfCodePointRanges().Any(range => range.Includes(aChar)) ||
                _configuration.BlacklistOfCodePoints().Contains(aChar);
        }

    }
}
