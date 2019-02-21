namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Class FileSystemValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations.SystemValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations.SystemValidationBase" />
    public class FileSystemValidation : SystemValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The drive letter
        /// </summary>
        private readonly char? _driveLetter;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="path">The path.</param>
        public FileSystemValidation(IConfiguration configuration, string path): base(configuration, "File system check", ValidationType.FileSystem)
        {
            _driveLetter = string.IsNullOrEmpty(path) ? null : new AfsPath(path).DriveLetter;
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate using.
        /// </summary>
        /// <param name="commandRunner">The command runner.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            if (!_driveLetter.HasValue)
            {
                return UnableToRunBecause(
                    @"Unable to perform the File System validation. In order to run this validation, specify 'Path' parameter such that it includes the drive letter, e.g. C:\MyDataSet or \\contoso-server\d$\data");
            }

            string filesystem;
            try
            {
                commandRunner.AddScript($"Get-Volume -DriveLetter {_driveLetter.Value}");
                PSObject volume = commandRunner.Invoke()[0];
                filesystem = (string)volume.Members["FileSystem"].Value;
            }
            catch (Exception e)
            {
                return UnableToRunBecause($"The File System validation was not able to run. Cause: {e.Message}");
            }

            if (IsValid(filesystem))
            {
                return SuccessfulResult;
            }

            return new ValidationResult
            {
                Description = $"The {filesystem} filesystem is not supported.",
                Level = ResultLevel.Error,
                Result = Result.Fail,
                Type = ValidationType,
                Kind = ValidationKind
            };
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="filesystem">The filesystem.</param>
        /// <returns><c>true</c> if the specified filesystem is valid; otherwise, <c>false</c>.</returns>
        private bool IsValid(string filesystem)
        {
            return Configuration.ValidFilesystems().Contains(filesystem);
        }

        /// <summary>
        /// Unables to run because.
        /// </summary>
        /// <param name="cause">The cause.</param>
        /// <returns>IValidationResult.</returns>
        private IValidationResult UnableToRunBecause(string cause)
        {
            return ValidationResult.UnavailableValidation(ValidationType, ValidationKind, cause);
        }
        #endregion
    }
}