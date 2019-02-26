// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using OutputWriters;
    using Validations.NamespaceValidations;
    using Validations.SystemValidations;
    using System;
    using System.Diagnostics;
    using Interfaces;
    using Models;
    using Microsoft.Azure.Commands.StorageSync.Properties;

    /// <summary>
    /// Class InvokeCompatibilityCheckCmdlet.
    /// Implements the <see cref="System.Management.Automation.Cmdlet" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.ICmdlet" />
    /// </summary>
    /// <seealso cref="System.Management.Automation.Cmdlet" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.ICmdlet" />
    [Cmdlet("Invoke", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageSyncCompatibilityCheck",DefaultParameterSetName="PathBased")]
    [OutputType(typeof(PSStorageSyncValidation))]
    public class InvokeCompatibilityCheckCmdlet : Cmdlet, ICmdlet
    {
        #region Fields and Properties

        /// <summary>
        /// The path
        /// </summary>
        private string _path;

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "PathBased")]
        public string Path {
            get
            {
                return _path;
            }
            set
            {
                _path = NormalizePath(value);
            }
        }

        /// <summary>
        /// Gets or sets the credential.
        /// </summary>
        /// <value>The credential.</value>
        [Parameter]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>The name of the computer.</value>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ComputerNameBased")]
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets the is network path.
        /// </summary>
        /// <value>The is network path.</value>
        private Lazy<bool> IsNetworkPath => new Lazy<bool>(() => 
        {
            if (!string.IsNullOrEmpty(Path))
            {
                var afsPath = new AfsPath(Path);
                if (afsPath.ComputerName != null)
                {
                    return true;
                }
            }
            return false;
        });

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        private string UserName
        {
            get
            {
                return Credential == null ? "the current user" : Credential.UserName;
            }
        }

        /// <summary>
        /// Gets the computer name value.
        /// </summary>
        /// <value>The computer name value.</value>
        private Lazy<string> ComputerNameValue => new Lazy<string>(() =>
        {
            if (!string.IsNullOrEmpty(Path))
            {
                var afsPath = new AfsPath(Path);
                if (afsPath.ComputerName != null)
                {
                    return afsPath.ComputerName;
                }

                return "localhost";
            }

            return ComputerName;
        });

        /// <summary>
        /// Gets or sets the skip system checks.
        /// </summary>
        /// <value>The skip system checks.</value>
        [Parameter]
        public SwitchParameter SkipSystemChecks { get; set; }

        /// <summary>
        /// Gets or sets the skip namespace checks.
        /// </summary>
        /// <value>The skip namespace checks.</value>
        [Parameter(ParameterSetName = "PathBased")]
        public SwitchParameter SkipNamespaceChecks { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance can run namespace checks.
        /// </summary>
        /// <value><c>true</c> if this instance can run namespace checks; otherwise, <c>false</c>.</value>
        private bool CanRunNamespaceChecks => !string.IsNullOrEmpty(Path);
        /// <summary>
        /// Gets a value indicating whether this instance can run estimation.
        /// </summary>
        /// <value><c>true</c> if this instance can run estimation; otherwise, <c>false</c>.</value>
        private bool CanRunEstimation => CanRunNamespaceChecks;
        /// <summary>
        /// Gets a value indicating whether this instance can run system checks.
        /// </summary>
        /// <value><c>true</c> if this instance can run system checks; otherwise, <c>false</c>.</value>
        private bool CanRunSystemChecks => !string.IsNullOrEmpty(ComputerNameValue.Value);

        /// <summary>
        /// Gets the maximum duration of namespace estimation.
        /// </summary>
        /// <value>The maximum duration of namespace estimation.</value>
        private TimeSpan MaximumDurationOfNamespaceEstimation => TimeSpan.FromSeconds(30);

        #endregion

        #region Protected methods
        /// <summary>
        /// Processes the record.
        /// </summary>
        protected override void ProcessRecord()
        {
            Configuration configuration = new Configuration();

            // prepare namespace validations
            IList<INamespaceValidation> namespaceValidations = ValidationsFactory.GetNamespaceValidations(configuration);

            // prepare system validations
            IList<ISystemValidation> systemValidations = ValidationsFactory.GetSystemValidations(configuration, Path);

            // output writers
            var validationResultWriter = new PSValidationResultOutputWriter();
            var outputWriters = new List<IOutputWriter>
            {
                validationResultWriter
            };

            WriteVerbose($"Path = {Path}");
            WriteVerbose($"ComputerName = {ComputerName}");
            WriteVerbose($"ComputerNameValue = {ComputerNameValue.Value}");
            WriteVerbose($"CanRunNamespaceChecks = {CanRunNamespaceChecks}");
            WriteVerbose($"CanRunSystemChecks = {CanRunSystemChecks}");
            WriteVerbose($"CanRunEstimation = {CanRunEstimation}");
            WriteVerbose($"SkipNamespaceChecks = {SkipNamespaceChecks}");
            WriteVerbose($"SkipSystemChecks = {SkipSystemChecks}");
            WriteVerbose($"NumberOfSystemChecks = {systemValidations.Count}");
            WriteVerbose($"NumberOfNamespaceChecks = {namespaceValidations.Count}");

            long totalObjectsToScan = 0;
            if (CanRunEstimation && !SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceEstimationProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(1);

                Stopwatch stopwatch = Stopwatch.StartNew();

                INamespaceInfo namespaceInfoEstimation;
                try
                {
                    namespaceInfoEstimation = RunActionWithUncConnectionIfNeeded<INamespaceInfo>(
                        () => new NamespaceEnumerator().Run(new AfsDirectoryInfo(Path), MaximumDurationOfNamespaceEstimation));
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    if (IsNetworkPath.Value)
                    {
                        WriteWarning(
                            $"Accessing network path {Path}' as {UserName} didn't work." + Environment.NewLine +
                            $"Consider using -Credential parameter to provide creentials of the user account with appropriate access.");
                    }
                    throw;
                }

                stopwatch.Stop();

                totalObjectsToScan += namespaceInfoEstimation.NumberOfDirectories + namespaceInfoEstimation.NumberOfFiles;
                progressReporter.CompleteStep();
                progressReporter.Complete();
                string namespaceCompleteness = namespaceInfoEstimation.IsComplete ? "complete" : "incomplete";
                TimeSpan duration = stopwatch.Elapsed;

                WriteVerbose($"Namespace estimation took {duration.TotalSeconds:F3} seconds and is {namespaceCompleteness}");
            }
            else
            {
                WriteVerbose("Skipping estimation.");
            }

            if (CanRunSystemChecks && !SkipSystemChecks.ToBool())
            {
                IProgressReporter progressReporter = new SystemCheckProgressReporter(this);
                progressReporter.Show();

                progressReporter.AddSteps(systemValidations.Count);
                Stopwatch stopwatch = Stopwatch.StartNew();
                PerformSystemChecks(systemValidations, progressReporter, this, outputWriters);
                stopwatch.Stop();
                progressReporter.Complete();
                TimeSpan duration = stopwatch.Elapsed;

                WriteVerbose($"System checks took {duration.TotalSeconds:F3} seconds");
            }
            else
            {
                WriteVerbose("Skipping system checks.");
            }

            INamespaceInfo namespaceInfo = null;
            if (CanRunNamespaceChecks && !SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceScanProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(totalObjectsToScan);

                Stopwatch stopwatch = Stopwatch.StartNew();
                namespaceInfo = RunActionWithUncConnectionIfNeeded<INamespaceInfo>(
                    () => StorageEval(namespaceValidations, progressReporter, this, outputWriters));
                stopwatch.Stop();
                progressReporter.Complete();

                TimeSpan duration = stopwatch.Elapsed;
                long namespaceFileCount = namespaceInfo.NumberOfFiles;
                double fileThroughput = namespaceFileCount > 0 ? duration.TotalMilliseconds / namespaceFileCount : 0.0;
                WriteVerbose($"Namespace scan took {duration.TotalSeconds:F3} seconds with throughput of {fileThroughput:F3} milliseconds per file");
            }
            else
            {
                WriteVerbose("Skipping namespace checks.");
            }

            var validationModel = validationResultWriter.Validation;
            validationModel.ComputerName = ComputerNameValue.Value;
            if (namespaceInfo != null)
            {
                validationModel.NamespacePath = namespaceInfo.Path;
                validationModel.NamespaceDirectoryCount = namespaceInfo.NumberOfDirectories;
                validationModel.NamespaceFileCount = namespaceInfo.NumberOfFiles;
            }
            WriteObject(validationModel);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Performs the system checks.
        /// </summary>
        /// <param name="validations">The validations.</param>
        /// <param name="progressReporter">The progress reporter.</param>
        /// <param name="cmdlet">The cmdlet.</param>
        /// <param name="outputWriters">The output writers.</param>
        private void PerformSystemChecks(IList<ISystemValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, IList<IOutputWriter> outputWriters)
        {
            PowerShellCommandRunner commandRunner = null;

            try
            {
                commandRunner = new PowerShellCommandRunner(ComputerNameValue.Value, Credential);
            }
            catch
            {
                WriteWarning(
                    $"Establishing management service connection with host '{ComputerNameValue.Value}' as {UserName} didn't work." + Environment.NewLine +
                    $"Ensure {UserName} has administrative rights and that the process is running with administrative permissions." + Environment.NewLine +
                    $"You can also use -SkipSystemChecks switch to skip system requirements checks.");
                throw;
            }

            SystemValidationsProcessor systemChecksProcessor = new SystemValidationsProcessor(commandRunner, validations, outputWriters, progressReporter);

            systemChecksProcessor.Run();
        }

        /// <summary>
        /// Runs the action with unc connection if needed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">The action.</param>
        /// <returns>T.</returns>
        private T RunActionWithUncConnectionIfNeeded<T>(Func<T> action)
        {
            T result = default(T);

            if (IsNetworkPath.Value && Credential != null)
            {
                using (UncNetworkConnector connector = new UncNetworkConnector())
                {
                    NetworkCredential networkCredential = Credential.GetNetworkCredential();
                    if (connector.NetUseWithCredentials(Path, networkCredential.UserName, networkCredential.Domain, networkCredential.Password))
                    {
                        result = action();
                    }
                    else
                    {
                        string errorMessage = connector.GetLastError();
                        WriteError(new ErrorRecord(new Exception(
                            string.Format(StorageSyncResources.InvokeCompatibilityCheckError1Format, Path,errorMessage)), errorMessage, ErrorCategory.ConnectionError, Path));
                    }
                }
            }
            else
            {
                result = action();
            }

            return result;
        }

        /// <summary>
        /// Storages the eval.
        /// </summary>
        /// <param name="validations">The validations.</param>
        /// <param name="progressReporter">The progress reporter.</param>
        /// <param name="cmdlet">The cmdlet.</param>
        /// <param name="outputWriters">The output writers.</param>
        /// <returns>INamespaceInfo.</returns>
        private INamespaceInfo StorageEval(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, IList<IOutputWriter> outputWriters)
        {
            IDirectoryInfo root = new AfsDirectoryInfo(Path);

            NamespaceValidationsProcessor validationsProcessor = new NamespaceValidationsProcessor(validations, outputWriters, progressReporter);

            List<INamespaceEnumeratorListener> namespaceEnumeratorListeners = new List<INamespaceEnumeratorListener>
            {
                validationsProcessor,
            };

            NamespaceEnumerator namespaceEnumerator = new NamespaceEnumerator(namespaceEnumeratorListeners);

            var namespaceInfo = namespaceEnumerator.Run(root);

            return namespaceInfo;
        }

        /// <summary>
        /// Normalizes the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string NormalizePath(string path)
        {
            string result = path?.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar);
            return result?.TrimEnd(System.IO.Path.DirectorySeparatorChar);
        }
        #endregion
    }
}
