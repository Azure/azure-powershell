using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    public class MaximumPathLengthValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public MaximumPathLengthValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo node)
        {
            return Validate((IFileSystemInfo) node);
        }

        public IValidationResult Validate(IDirectoryInfo node)
        {
            return Validate((IFileSystemInfo) node);
        }

        private IValidationResult Validate(IFileSystemInfo node)
        {
            int maxPathLength = _configuration.MaximumPathLength();

            AFSPath path = new AFSPath(node.FullName);
            int pathLength = path.Length();

            bool pathIsTooLong = pathLength > maxPathLength;
            if (pathIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} path's is too long. Maximum path length is {maxPathLength}.",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType.PathLength

                };
            }


            return ValidationResult.SuccessfullValidationResult(ValidationType.PathLength);
        }

    }
}