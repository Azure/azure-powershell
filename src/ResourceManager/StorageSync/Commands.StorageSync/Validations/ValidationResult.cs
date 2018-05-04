using System;
using System.Collections.Generic;

namespace AFSEvaluationTool.Validations
{
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
    }
}