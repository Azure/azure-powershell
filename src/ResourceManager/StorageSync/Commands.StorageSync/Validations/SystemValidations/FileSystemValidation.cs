using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    public class FileSystemValidation : ISystemValidation
    {
        private readonly char _driveLetter;

        private readonly IConfiguration _configuration;

        private readonly bool _haveDriveLetter;

        public FileSystemValidation(IConfiguration configuration, string path)
        {
            if (IsDriveSpecified(path))
            {
                _driveLetter = path[0];
                _haveDriveLetter = true;
            }
            else
            {
                _haveDriveLetter = false;
            }

            _configuration = configuration;
        }

        private bool IsDriveSpecified(string path)
        {
            return Char.IsLetter(path[0]) && path[0] <= 0x007a;
        }

        public IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner)
        {
            if (!_haveDriveLetter)
            {
                return UnableToRunBecause(
                    "Unable to perform the File System validation. The path provided does not includes a drive.");
            }

            string filesystem;
            try
            {
                commandRunner.AddScript($"Get-Volume -DriveLetter {_driveLetter}");
                PSObject volume = commandRunner.Invoke()[0];
                filesystem = (string)volume.Members["FileSystem"].Value;
            }
            catch (Exception e)
            {
                return UnableToRunBecause($"The File System validation was not able to run. Cause: {e.Message}");
            }

            if (IsValid(filesystem))
            {
                return ValidationResult.SuccessfullValidationResult(ValidationType.FileSystem);
            }
            
            
            return new ValidationResult
            {
                Description = $"The {filesystem} filesystem is not supported.",
                Level = ResultLevel.Error,
                Result = Result.Fail,
                Type = ValidationType.FileSystem
            };
        }

        private bool IsValid(string filesystem)
        {
            return _configuration.ValidFilesystems().Contains(filesystem);
        }

        private IValidationResult UnableToRunBecause(string cause)
        {
            return ValidationResult.UnavailableValidation(ValidationType.FileSystem, cause);
        }
    }
}