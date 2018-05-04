using System;

namespace AFSEvaluationTool.Validations.NamespaceValidations
{
    public class MaximumTreeDepthValidation : INamespaceValidation
    {
        private readonly IConfiguration _configuration;

        public MaximumTreeDepthValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult Validate(IFileInfo node)
        {
            return Validate((IFileSystemInfo) node);
        }

        public IValidationResult Validate(IDirectoryInfo node)
        {
            return Validate((IFileSystemInfo)node);
        }

        private IValidationResult Validate(IFileSystemInfo node)
        {
            int maxTreeDepth = _configuration.MaximumTreeDepth();
            AFSPath path = new AFSPath(node.FullName);
            int depth = path.Depth();

            bool isTooDeep = depth > maxTreeDepth;
            if (isTooDeep)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Node {node.Name} is too deep in the directory tree. Maximum tree depth is {maxTreeDepth}.",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = ValidationType.NodeDepth

                };
            }

            return ValidationResult.SuccessfullValidationResult(ValidationType.NodeDepth);
        }

    }
}