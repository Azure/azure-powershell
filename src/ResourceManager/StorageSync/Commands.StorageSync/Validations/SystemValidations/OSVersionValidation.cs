using System;
using System.Linq;

namespace AFSEvaluationTool.Validations.SystemValidations
{
    public class OSVersionValidation : ISystemValidation
    {
        private readonly IConfiguration _configuration;

        public OSVersionValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner)
        {
            string osVersion;
            try
            {
                commandRunner.AddScript("Get-CimInstance Win32_OperatingSystem");
                osVersion = (string)commandRunner.Invoke()[0].Members["version"].Value;
            }
            catch (Exception e)
            {
                return ValidationResult.UnavailableValidation(ValidationType.OsVersion,
                    $"The OS Version validation was not able to complete. Cause: {e.Message}");
            }
            

            if (IsValid(osVersion))
            {
                return ValidationResult.SuccessfullValidationResult(ValidationType.OsVersion);
            }

            return new ValidationResult()
            {
                Description = $"The {osVersion} OS version is not supported.",
                Level = ResultLevel.Error,
                Type = ValidationType.OsVersion,
                Result = Result.Fail
            };
        }

        private bool IsValid(string osVersion)
        {
            return _configuration.ValidOsVersions().Contains(osVersion);
        }
    }
}