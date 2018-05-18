using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{

    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmStorageSyncCompatibilityCheck")]
    [OutputType(typeof(object))]
    public class InvokeCompatibilityCheckCmdlet : Cmdlet, ICmdlet
    {
        #region Fields and Properties
        [Parameter(Mandatory = true, Position = 0)]
        public string Path { get; set; }

        [Parameter]
        public PSCredential Credential { get; set; }

        [Parameter]
        public string ComputerName { get; set; }

        [Parameter]
        public SwitchParameter SkipSystemChecks { get; set; }

        [Parameter]
        public SwitchParameter SkipNamespaceChecks { get; set; }
        #endregion

        #region Protected methods
        protected override void ProcessRecord()
        {
            Configuration configuration = new Configuration();

            long totalObjectsToScan = 0;
            if (!string.IsNullOrEmpty(this.Path))
            {
                IProgressReporter progressReporter = new NamespaceEstimationProgressReporter(this);
                progressReporter.Show();
                progressReporter.AddSteps(1);
                INamespaceInfo namespaceInfo = new NamespaceEnumerator().Run(new AfsDirectoryInfo(this.Path));
                totalObjectsToScan += namespaceInfo.NumberOfDirectories + namespaceInfo.NumberOfFiles;
                progressReporter.CompleteStep();
                progressReporter.Complete();
            }

            TextSummaryOutputWriter summaryWriter = new TextSummaryOutputWriter(Path, new AfsConsoleWriter());
            PsObjectsOutputWriter psObjectsWriter = new PsObjectsOutputWriter(this);

            if (!SkipSystemChecks.ToBool())
            {
                IProgressReporter progressReporter = new NamespaceScanProgressReporter(this);
                progressReporter.Show();

                var validations = new List<ISystemValidation>
                {
                    new OSVersionValidation(configuration),
                    new FileSystemValidation(configuration, Path)
                };

                progressReporter.AddSteps(validations.Count);

                PerformSystemChecks(validations, progressReporter, this, summaryWriter, psObjectsWriter);

                progressReporter.Complete();
            }

            if (!SkipNamespaceChecks.ToBool())
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

                PerformNamespaceChecks(validations, progressReporter, this, summaryWriter, psObjectsWriter);

                progressReporter.Complete();
            }

        }
        #endregion

        #region Private methods
        private void PerformSystemChecks(IList<ISystemValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            PowerShellCommandRunner commandRunner = new PowerShellCommandRunner(ComputerName, Credential);

            var outputWriters = new List<IOutputWriter>
            {
                summaryWriter,
                psObjectsWriter
            };

            SystemValidationsProcessor systemChecksProcessor = new SystemValidationsProcessor(commandRunner, validations, outputWriters, progressReporter);

            systemChecksProcessor.Run();
        }

        private void PerformNamespaceChecks(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            if (Credential != null)
            {
                using (UncNetworkConnector connector = new UncNetworkConnector())
                {
                    NetworkCredential networkCredential = Credential.GetNetworkCredential();
                    if (connector.NetUseWithCredentials(Path, networkCredential.UserName, networkCredential.Domain, networkCredential.Password))
                    {
                        StorageEval(validations, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
                    }
                    else
                    {
                        WriteObject(connector.GetLastError());
                    }
                }
            }
            else
            {
                StorageEval(validations, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
            }
        }

        private void StorageEval(IList<INamespaceValidation> validations, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
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
                summaryWriter
            };

            NamespaceEnumerator namespaceEnumerator = new NamespaceEnumerator(namespaceEnumeratorListeners);

            namespaceEnumerator.Run(root);
        }
        #endregion
    }
}