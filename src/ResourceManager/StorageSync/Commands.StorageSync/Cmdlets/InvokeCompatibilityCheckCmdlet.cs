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

    [Cmdlet("Invoke", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageSyncCompatibilityCheck",DefaultParameterSetName="PathBased")]
    [OutputType(typeof(PSValidationResult))]
    public class InvokeCompatibilityCheckCmdlet : Cmdlet, ICmdlet
    {
        #region Fields and Properties

        private string _path;

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "PathBased")]
        public string Path {
            get
            {
                return this._path;
            }
            set
            {
                this._path = this.NormalizePath(value);
            }
        }

        [Parameter]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ComputerNameBased")]
        public string ComputerName { get; set; }

        private Lazy<bool> IsNetworkPath => new Lazy<bool>(() => 
        {
            if (!string.IsNullOrEmpty(this.Path))
            {
                var afsPath = new AfsPath(this.Path);
                if (afsPath.ComputerName != null)
                {
                    return true;
                }
            }
            return false;
        });

        private string UserName
        {
            get
            {
                return this.Credential == null ? "the current user" : this.Credential.UserName;
            }
        }

        private Lazy<string> ComputerNameValue => new Lazy<string>(() =>
        {
            if (!string.IsNullOrEmpty(this.Path))
            {
                var afsPath = new AfsPath(this.Path);
                if (afsPath.ComputerName != null)
                {
                    return afsPath.ComputerName;
                }

                return "localhost";
            }

            return this.ComputerName;
        });

        [Parameter]
        public SwitchParameter SkipSystemChecks { get; set; }

        [Parameter(ParameterSetName = "PathBased")]
        public SwitchParameter SkipNamespaceChecks { get; set; }

        [Parameter]
        public SwitchParameter Quiet { get; set; }

        private bool CanRunNamespaceChecks => !string.IsNullOrEmpty(this.Path);
        private bool CanRunEstimation => this.CanRunNamespaceChecks;
        private bool CanRunSystemChecks => !string.IsNullOrEmpty(this.ComputerNameValue.Value);

        private TimeSpan MaximumDurationOfNamespaceEstimation => TimeSpan.FromSeconds(30);

        #endregion

        #region Protected methods
        protected override void ProcessRecord()
        {
            Configuration configuration = new Configuration();

            // prepare namespace validations
            var namespaceValidations = new List<INamespaceValidation>()
            {
                new InvalidFilenameValidation(configuration),
                new FilenamesCharactersValidation(configuration),
                new MaximumFileSizeValidation(configuration),
                new MaximumPathLengthValidation(configuration),
                new MaximumFilenameLengthValidation(configuration),
                new MaximumTreeDepthValidation(configuration),
                new MaximumDatasetSizeValidation(configuration),
            };

            // prepare system validations
            var systemValidations = new List<ISystemValidation>
            {
                new OSVersionValidation(configuration),
            };

            if (this.CanRunNamespaceChecks)
            {
                systemValidations.Add(new FileSystemValidation(configuration, this.Path));
            }

            // construct validation descriptions
            List<IValidationDescription> validationDescriptions = new List<IValidationDescription>();
            namespaceValidations.ForEach(o => validationDescriptions.Add((IValidationDescription)o));
            systemValidations.ForEach(o => validationDescriptions.Add((IValidationDescription)o));

            // output writers
            TextSummaryOutputWriter summaryWriter = new TextSummaryOutputWriter(new AfsConsoleWriter(), validationDescriptions);
            PsObjectsOutputWriter psObjectsWriter = new PsObjectsOutputWriter(this);

            this.WriteVerbose($"Path = {this.Path}");
            this.WriteVerbose($"ComputerName = {this.ComputerName}");
            this.WriteVerbose($"ComputerNameValue = {this.ComputerNameValue.Value}");
            this.WriteVerbose($"CanRunNamespaceChecks = {this.CanRunNamespaceChecks}");
            this.WriteVerbose($"CanRunSystemChecks = {this.CanRunSystemChecks}");
            this.WriteVerbose($"CanRunEstimation = {this.CanRunEstimation}");
            this.WriteVerbose($"SkipNamespaceChecks = {this.SkipNamespaceChecks}");
            this.WriteVerbose($"SkipSystemChecks = {this.SkipSystemChecks}");
            this.WriteVerbose($"Quiet = {this.Quiet}");
            this.WriteVerbose($"NumberOfSystemChecks = {systemValidations.Count}");
            this.WriteVerbose($"NumberOfNamespaceChecks = {namespaceValidations.Count}");

            long totalObjectsToScan = 0;
            if (this.CanRunEstimation && !this.SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceEstimationProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(1);

                Stopwatch stopwatch = Stopwatch.StartNew();

                INamespaceInfo namespaceInfoEstimation;
                try
                {
                    namespaceInfoEstimation = this.RunActionWithUncConnectionIfNeeded<INamespaceInfo>(
                        () => new NamespaceEnumerator().Run(new AfsDirectoryInfo(this.Path), this.MaximumDurationOfNamespaceEstimation));
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    if (this.IsNetworkPath.Value)
                    {
                        this.WriteWarning(
                            $"Accessing network path {this.Path}' as {this.UserName} didn't work." + Environment.NewLine +
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

                this.WriteVerbose($"Namespace estimation took {duration.TotalSeconds:F3} seconds and is {namespaceCompleteness}");
            }
            else
            {
                this.WriteVerbose("Skipping estimation.");
            }

            if (this.CanRunSystemChecks && !this.SkipSystemChecks.ToBool())
            {
                IProgressReporter progressReporter = new SystemCheckProgressReporter(this);
                progressReporter.Show();

                progressReporter.AddSteps(systemValidations.Count);
                Stopwatch stopwatch = Stopwatch.StartNew();
                this.PerformSystemChecks(systemValidations, progressReporter, this, summaryWriter, psObjectsWriter);
                stopwatch.Stop();
                progressReporter.Complete();
                TimeSpan duration = stopwatch.Elapsed;

                this.WriteVerbose($"System checks took {duration.TotalSeconds:F3} seconds");
            }
            else
            {
                this.WriteVerbose("Skipping system checks.");
            }

            INamespaceInfo namespaceInfo = null;
            if (this.CanRunNamespaceChecks && !this.SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceScanProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(totalObjectsToScan);

                Stopwatch stopwatch = Stopwatch.StartNew();
                namespaceInfo = this.RunActionWithUncConnectionIfNeeded<INamespaceInfo>(
                    () => this.StorageEval(namespaceValidations, progressReporter, this, summaryWriter, psObjectsWriter));
                stopwatch.Stop();
                progressReporter.Complete();

                TimeSpan duration = stopwatch.Elapsed;
                long namespaceFileCount = namespaceInfo.NumberOfFiles;
                double fileThroughput = namespaceFileCount > 0 ? duration.TotalMilliseconds / namespaceFileCount : 0.0;
                this.WriteVerbose($"Namespace scan took {duration.TotalSeconds:F3} seconds with throughput of {fileThroughput:F3} milliseconds per file");
            }
            else
            {
                this.WriteVerbose("Skipping namespace checks.");
            }

            if (!this.Quiet.ToBool())
            {
                summaryWriter.WriteReport(this.ComputerNameValue.Value, namespaceInfo);
            }
            else
            {
                this.WriteVerbose("Skipping report.");
            }
        }
        #endregion

        #region Private methods
        private void PerformSystemChecks(IList<ISystemValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            PowerShellCommandRunner commandRunner = null;

            try
            {
                commandRunner = new PowerShellCommandRunner(this.ComputerNameValue.Value, this.Credential);
            }
            catch
            {
                this.WriteWarning(
                    $"Establishing management service connection with host '{this.ComputerNameValue.Value}' as {this.UserName} didn't work." + Environment.NewLine +
                    $"Ensure {this.UserName} has administrative rights and that the process is running with administrative permissions." + Environment.NewLine +
                    $"You can also use -SkipSystemChecks switch to skip system requirements checks.");
                throw;
            }

            var outputWriters = new List<IOutputWriter>
            {
                summaryWriter,
                psObjectsWriter
            };

            SystemValidationsProcessor systemChecksProcessor = new SystemValidationsProcessor(commandRunner, validations, outputWriters, progressReporter);

            systemChecksProcessor.Run();
        }

        private T RunActionWithUncConnectionIfNeeded<T>(Func<T> action)
        {
            T result = default(T);

            if (this.IsNetworkPath.Value && this.Credential != null)
            {
                using (UncNetworkConnector connector = new UncNetworkConnector())
                {
                    NetworkCredential networkCredential = this.Credential.GetNetworkCredential();
                    if (connector.NetUseWithCredentials(this.Path, networkCredential.UserName, networkCredential.Domain, networkCredential.Password))
                    {
                        result = action();
                    }
                    else
                    {
                        string errorMessage = connector.GetLastError();
                        WriteError(new ErrorRecord(new Exception($"Failed mounting network path {this.Path}. Error: {errorMessage}"), errorMessage, ErrorCategory.ConnectionError, this.Path));
                    }
                }
            }
            else
            {
                result = action();
            }

            return result;
        }

        private INamespaceInfo StorageEval(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            IDirectoryInfo root = new AfsDirectoryInfo(this.Path);

            var outputWriters = new List<IOutputWriter>
            {
                psObjectsWriter,
                summaryWriter
            };

            NamespaceValidationsProcessor validationsProcessor = new NamespaceValidationsProcessor(validations, outputWriters, progressReporter);

            List<INamespaceEnumeratorListener> namespaceEnumeratorListeners = new List<INamespaceEnumeratorListener>
            {
                validationsProcessor,
            };

            NamespaceEnumerator namespaceEnumerator = new NamespaceEnumerator(namespaceEnumeratorListeners);

            var namespaceInfo = namespaceEnumerator.Run(root);

            return namespaceInfo;
        }

        private string NormalizePath(string path)
        {
            string result = path?.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar);
            return result?.TrimEnd(System.IO.Path.DirectorySeparatorChar);
        }
        #endregion
    }
}
