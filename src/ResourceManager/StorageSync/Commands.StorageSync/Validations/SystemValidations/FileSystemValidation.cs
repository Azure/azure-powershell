using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
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
            AfsPath afsPath = new AfsPath(path);
            string computerName;

            if (afsPath.TryGetDriveLetterFromPath(out _driveLetter))
            {
                _haveDriveLetter = true;
            }
            else if (afsPath.TryGetComputerNameAndDriveFromPath(out computerName, out _driveLetter))
            {
                _haveDriveLetter = true;
            }
            else
            {
                _haveDriveLetter = false;
            }

            _configuration = configuration;
        }

        public IValidationResult ValidateUsing(IPowershellCommandRunner commandRunner)
        {
            if (!_haveDriveLetter)
            {
                return UnableToRunBecause(
                    @"Unable to perform the File System validation. In order to run this validation, specify 'Path' parameter such that it includes the drive letter, e.g. C:\MyDataSet or \\contoso-server\d$\data");
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