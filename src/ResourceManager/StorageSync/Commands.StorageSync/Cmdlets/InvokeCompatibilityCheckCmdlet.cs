using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;
using System.Text.RegularExpressions;
using System;
using System.Diagnostics;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{

    [Cmdlet(
        VerbsLifecycle.Invoke, "AzureRmStorageSyncCompatibilityCheck", 
        DefaultParameterSetName="PathBased")]
    [OutputType(typeof(object))]
    public class InvokeCompatibilityCheckCmdlet : Cmdlet, ICmdlet
    {
        #region Fields and Properties
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "PathBased")]
        public string Path { get; set; }

        [Parameter]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ComputerNameBased")]
        public string ComputerName { get; set; }

        private string ComputerNameValue {
            get
            {
                var afsPath = new AfsPath(this.Path);
                string computerName;
                string shareName;
                if (afsPath.TryGetComputerNameAndShareFromPath(out computerName, out shareName))
                {
                    return computerName;
                }

                if (!string.IsNullOrEmpty(this.ComputerName))
                {
                    return this.ComputerName;
                }

                return null;
            }
        }

        [Parameter]
        public SwitchParameter SkipSystemChecks { get; set; }

        [Parameter]
        public SwitchParameter SkipNamespaceChecks { get; set; }

        [Parameter]
        public SwitchParameter Quiet { get; set; }
        #endregion

        private bool CanRunNamespaceChecks => !string.IsNullOrEmpty(this.Path);
        private bool CanRunEstimation => CanRunNamespaceChecks;
        private bool CanRunSystemChecks => true;

        #region Protected methods
        protected override void ProcessRecord()
        {
            Configuration configuration = new Configuration();

            this.WriteVerbose($"Path = {this.Path}");
            this.WriteVerbose($"ComputerName = {this.ComputerName}");
            this.WriteVerbose($"ComputerNameValue = {this.ComputerNameValue}");
            this.WriteVerbose($"CanRunNamespaceChecks = {this.CanRunNamespaceChecks}");
            this.WriteVerbose($"CanRunSystemChecks = {this.CanRunSystemChecks}");
            this.WriteVerbose($"CanRunEstimation = {this.CanRunEstimation}");
            this.WriteVerbose($"SkipNamespaceChecks = {this.SkipNamespaceChecks}");
            this.WriteVerbose($"SkipSystemChecks = {this.SkipSystemChecks}");
            this.WriteVerbose($"Quiet = {this.Quiet}");

            long totalObjectsToScan = 0;
            if (this.CanRunEstimation && !SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceEstimationProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(1);

                Stopwatch stopwatch = Stopwatch.StartNew();
                INamespaceInfo namespaceInfo = new NamespaceEnumerator().Run(new AfsDirectoryInfo(this.Path), TimeSpan.FromSeconds(5));
                stopwatch.Stop();

                totalObjectsToScan += namespaceInfo.NumberOfDirectories + namespaceInfo.NumberOfFiles;
                progressReporter.CompleteStep();
                progressReporter.Complete();
                string namespaceCompleteness = namespaceInfo.IsComplete ? "complete" : "incomplete";
                TimeSpan duration = stopwatch.Elapsed;
                WriteVerbose($"Namespace estimation took {duration.TotalSeconds:F3} seconds and is {namespaceCompleteness}");
            }
            else
            {
                WriteVerbose("Skipping estimation.");
            }

            TextSummaryOutputWriter summaryWriter = new TextSummaryOutputWriter(Path, new AfsConsoleWriter());
            PsObjectsOutputWriter psObjectsWriter = new PsObjectsOutputWriter(this);

            if (this.CanRunSystemChecks && !SkipSystemChecks.ToBool())
            {
                IProgressReporter progressReporter = new SystemCheckProgressReporter(this);
                progressReporter.Show();

                var validations = new List<ISystemValidation>
                {
                    new OSVersionValidation(configuration),
                    new FileSystemValidation(configuration, Path)
                };

                progressReporter.AddSteps(validations.Count);

                Stopwatch stopwatch = Stopwatch.StartNew();
                PerformSystemChecks(validations, progressReporter, this, summaryWriter, psObjectsWriter);
                stopwatch.Stop();

                PerformSystemChecks(validations, progressReporter, this, summaryWriter, psObjectsWriter);
                progressReporter.Complete();
                TimeSpan duration = stopwatch.Elapsed;

                WriteVerbose($"System checks took {duration.TotalSeconds:F3} seconds");
            }
            else
            {
                WriteVerbose("Skipping system checks.");
            }

            if (this.CanRunNamespaceChecks && !SkipNamespaceChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceScanProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(totalObjectsToScan);

                var validations = new List<INamespaceValidation>()
                {
                    new InvalidFilenameValidation(configuration),
                    new FilenamesCharactersValidation(configuration),
                    new MaximumFileSizeValidation(configuration),
                    new MaximumPathLengthValidation(configuration),
                    new MaximumFilenameLengthValidation(configuration),
                    new MaximumTreeDepthValidation(configuration),
                    new MaximumDatasetSizeValidation(configuration),
                };

                Stopwatch stopwatch = Stopwatch.StartNew();
                INamespaceInfo namespaceInfo = PerformNamespaceChecks(validations, progressReporter, this, summaryWriter, psObjectsWriter);
                stopwatch.Stop();
                progressReporter.Complete();

                TimeSpan duration = stopwatch.Elapsed;
                var namespaceFileCount = namespaceInfo.NumberOfFiles;
                double fileThroughput = namespaceFileCount > 0 ? duration.TotalMilliseconds / namespaceFileCount : 0.0;
                WriteVerbose($"Namespace scan took {duration.TotalSeconds:F3} seconds with throughput of {fileThroughput:F3} milliseconds per file");
            }
            else
            {
                WriteVerbose("Skipping namespace checks.");
            }

        }
        #endregion

        #region Private methods
        private void PerformSystemChecks(IList<ISystemValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            PowerShellCommandRunner commandRunner = null;

            try
            {
                commandRunner = new PowerShellCommandRunner(ComputerNameValue, Credential);
            }
            catch
            {
                this.WriteWarning("Establishing connection didn't work. Consider using -SkipSystemChecks switch to skip it.");
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

        private INamespaceInfo PerformNamespaceChecks(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            INamespaceInfo result = null;

            if (Credential != null)
            {
                using (UncNetworkConnector connector = new UncNetworkConnector())
                {
                    NetworkCredential networkCredential = Credential.GetNetworkCredential();
                    if (connector.NetUseWithCredentials(Path, networkCredential.UserName, networkCredential.Domain, networkCredential.Password))
                    {
                        result = StorageEval(validations, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
                    }
                    else
                    {
                        WriteObject(connector.GetLastError());
                    }
                }
            }
            else
            {
                result = StorageEval(validations, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
            }

            return result;
        }

        private INamespaceInfo StorageEval(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(Path);
            IDirectoryInfo root = new AfsDirectoryInfo(rootDirectoryInfo);

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

            if (!this.Quiet.ToBool())
            {
                summaryWriter.WriteReport(namespaceInfo);
            }
            else
            {
                WriteVerbose("Skipping report.");
            }

            return namespaceInfo;
        }
        #endregion
    }
}