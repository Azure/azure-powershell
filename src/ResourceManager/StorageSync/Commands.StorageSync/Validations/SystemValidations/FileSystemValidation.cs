namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Management.Automation;

    public class FileSystemValidation : BaseSystemValidation
    {
        #region Fields and Properties
        private readonly char? _driveLetter;
        #endregion

        #region Constructors
        public FileSystemValidation(IConfiguration configuration, string path): base(configuration, "File system check", ValidationType.FileSystem)
        {
            this._driveLetter = new AfsPath(path).DriveLetter;
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            if (!this._driveLetter.HasValue)
            {
                return this.UnableToRunBecause(
                    @"Unable to perform the File System validation. In order to run this validation, specify 'Path' parameter such that it includes the drive letter, e.g. C:\MyDataSet or \\contoso-server\d$\data");
            }

            string filesystem;
            try
            {
                commandRunner.AddScript($"Get-Volume -DriveLetter {this._driveLetter.Value}");
                PSObject volume = commandRunner.Invoke()[0];
                filesystem = (string)volume.Members["FileSystem"].Value;
            }
            catch (Exception e)
            {
                return this.UnableToRunBecause($"The File System validation was not able to run. Cause: {e.Message}");
            }

            if (this.IsValid(filesystem))
            {
                return this.SuccessfulResult;
            }

            return new ValidationResult
            {
                Description = $"The {filesystem} filesystem is not supported.",
                Level = ResultLevel.Error,
                Result = Result.Fail,
                Type = this.ValidationType
            };
        }
        #endregion

        #region Private methods
        private bool IsValid(string filesystem)
        {
            return this.Configuration.ValidFilesystems().Contains(filesystem);
        }

        private IValidationResult UnableToRunBecause(string cause)
        {
            return ValidationResult.UnavailableValidation(this.ValidationType, cause);
        }
        #endregion
    }
}