using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.AggregateValidations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{

    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmStorageSyncCompatibilityCheck")]
    [OutputType(typeof(object))]
    public class InvokeAzureRmStorageSyncCompatibilityCheckCmdlet : Cmdlet
    {
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
      
        protected override void ProcessRecord()
        {            
            using (TelemetryEventSourceContract Logger = new TelemetryEventSourceContract())
            {
                Logger.AppRan("dsfiuiwersdvscnmcbviowuerfbw");
            }
            
            Configuration configuration = new Configuration();

            ICmdlet cmdlet = new AFSCmdlet(this);
            ProgressReporter progressReporter = new ProgressReporter(cmdlet);
            NodeCounter nodeCounter = new NodeCounter();

            if (!string.IsNullOrEmpty(this.Path))
            {
                DirectoryInfo rootDirectoryInfo = new DirectoryInfo(Path);
                IDirectoryInfo root = new AFSDirectoryInfo(rootDirectoryInfo);
                long nodeCount = nodeCounter.Count(root);
                progressReporter.AddSteps(nodeCount);
            }

            TextSummaryOutputWriter summaryWriter = new TextSummaryOutputWriter(Path, new AFSConsoleWriter());
            PsObjectsOutputWriter psObjectsWriter = new PsObjectsOutputWriter(cmdlet);

            if (!SkipSystemChecks.ToBool())
            {
                PerformSystemChecks(configuration, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
            }

            if (!SkipNamespaceChecks.ToBool())
            {
                PerformNamespaceChecks(configuration, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
            }
            
        }

        private void PerformSystemChecks(IConfiguration configuration, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            PowerShellCommandRunner commandRunner = new PowerShellCommandRunner(ComputerName, Credential);
            IEnumerable<ISystemValidation> validations = new List<ISystemValidation>()
            {
                new OSVersionValidation(configuration),
                new FileSystemValidation(configuration, Path)
            };
            progressReporter.AddSteps(validations.Count());
            IEnumerable<IOutputWriter> outputWriters = new List<IOutputWriter>()
            {
                summaryWriter,
                psObjectsWriter

            };
            SystemValidationsProcessor systemChecksProcessor = new SystemValidationsProcessor(commandRunner, validations, outputWriters, progressReporter);

            systemChecksProcessor.Run();
        }

        private void PerformNamespaceChecks(IConfiguration configuration, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            if (Credential != null)
            {
                using (UNCNetworkConnector connector = new UNCNetworkConnector())
                {
                    NetworkCredential networkCredential = Credential.GetNetworkCredential();
                    if (connector.NetUseWithCredentials(Path, networkCredential.UserName, networkCredential.Domain, networkCredential.Password))
                    {
                        StorageEval(configuration, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
                    }
                    else
                    {
                        WriteObject(connector.GetLastError());
                    }
                }
            }
            else
            {
                StorageEval(configuration, progressReporter, cmdlet, summaryWriter, psObjectsWriter);
            }
        }

        private void StorageEval(IConfiguration configuration, IProgressReporter progressReporter, ICmdlet cmdlet, TextSummaryOutputWriter summaryWriter, PsObjectsOutputWriter psObjectsWriter)
        {
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(Path);
            IDirectoryInfo root = new AFSDirectoryInfo(rootDirectoryInfo);
           
            IEnumerable<INamespaceValidation> validations = new List<INamespaceValidation>()
            {
                new InvalidFilenameValidation(configuration),
                new FilenamesCharactersValidation(configuration),
                new MaximumFileSizeValidation(configuration),
                new MaximumPathLengthValidation(configuration),
                new MaximumFilenameLengthValidation(configuration),
                new MaximumTreeDepthValidation(configuration)
                
            };
            
            IEnumerable<IOutputWriter> outputWriters = new List<IOutputWriter>()
            {
                psObjectsWriter,
                summaryWriter
            };
            NamespaceValidationsProcessor validationsProcessor= new NamespaceValidationsProcessor(validations, outputWriters, progressReporter);
            MaximumDatasetSizeValidation maximumDatasetSizeValidation = new MaximumDatasetSizeValidation(configuration, outputWriters);
            List<INamespaceEnumeratorListener> namespaceEnumeratorListeners = new List<INamespaceEnumeratorListener>
            {
                validationsProcessor,
                maximumDatasetSizeValidation,
                summaryWriter
            };
            NamespaceEnumerator namespaceEnumerator = new NamespaceEnumerator(namespaceEnumeratorListeners);
            
            namespaceEnumerator.Run(root);
        }

    }
}