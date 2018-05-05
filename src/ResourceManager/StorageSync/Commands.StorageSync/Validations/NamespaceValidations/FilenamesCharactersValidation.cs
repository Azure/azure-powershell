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
            if (node.Name.Any(c => IsBlacklisted(c)))
            {
                int position = 0;
                while (!IsBlacklisted(node.Name[position]))
                {
                    ++position;
                }

                return new ValidationResult
                {
                    Result = Result.Fail,
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType.FilenameCharacters,
                    Description = $"File {node.Name} has an unsupported character in position {position}."
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
