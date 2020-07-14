using Azure.Analytics.Synapse.Artifacts.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook)]
    [OutputType(typeof(PSNotebookResource))]
    public class SetAzureSynapseNotebook : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.NotebookName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Nbformat)]
        [ValidateNotNullOrEmpty]
        public int Nbformat { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NbformatMinor)]
        [ValidateNotNullOrEmpty]
        public int NbformatMinor { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NotebookDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.SparkPoolName)]
        [ValidateNotNullOrEmpty]
        public string SparkPool { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ExecutorSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string ExecutorSize { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NodeCount)]
        [ValidateRange(1, 200)]
        public int NodeCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Language)]
        [ValidateSet(LanguageType.Python, LanguageType.Scala, LanguageType.CSharp, LanguageType.SparkSql, IgnoreCase = true)]
        [PSArgumentCompleter(LanguageType.Python, LanguageType.Scala, LanguageType.CSharp, LanguageType.SparkSql)]
        public string Language { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (!this.IsParameterBound(c => c.Nbformat))
            {
                this.Nbformat = 4;
            }

            if (!this.IsParameterBound(c => c.NbformatMinor))
            {
                this.NbformatMinor = 2;
            }

            if (!this.IsParameterBound(c => c.Language))
            {
                this.Language = LanguageType.Python;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseNotebook, this.Name, this.WorkspaceName)))
            {
                NotebookMetadata metadata = new NotebookMetadata
                {
                    LanguageInfo = new NotebookLanguageInfo(this.Language),
                };

                var options = new ComputeOptions();
                if (this.IsParameterBound(c => c.SparkPool))
                {
                    string suffix = DefaultContext.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
                    string endpoint = "https://" + this.WorkspaceName + "." + suffix;
                    var sparkPoolInfo = new SynapseAnalyticsManagementClient(DefaultContext).GetSparkPool(null, this.WorkspaceName, this.SparkPool);

                    options["auth"] = new ComputeOptions
                    {
                        ["type"] = "AAD",
                        ["authResource"] = "https://dev.azuresynapse.net"
                    };
                    options["cores"] = this.IsParameterBound(c => c.ExecutorSize) ? SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores : 4;
                    options["endpoint"] = endpoint + "/livyApi/versions/2019-11-01-priview/sparkPools" + this.SparkPool;
                    options["extraHeader"] = new ComputeOptions();
                    options["id"] = sparkPoolInfo.Id;
                    options["memory"] = this.IsParameterBound(c => c.ExecutorSize) ? SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory : 28;
                    options["name"] = this.SparkPool;
                    options["nodeCount"] = this.IsParameterBound(c => c.NodeCount) ? this.NodeCount : 1;
                    options["sparkVersion"] = sparkPoolInfo.SparkVersion;
                    options["type"] = "Spark";
                    metadata["a365ComputeOptions"] = options;
                }
                
                IEnumerable<NotebookCell> cells = new List<NotebookCell>();
                Notebook notebook = new Notebook(metadata, this.Nbformat, this.NbformatMinor, cells)
                {
                    Description = this.Description,
                    BigDataPool = this.IsParameterBound(c => c.SparkPool) ? new BigDataPoolReference(this.SparkPool) : null,
                    SessionProperties = this.IsParameterBound(c => c.SparkPool) ? new NotebookSessionProperties(options["memory"]+"g", (int)options["cores"], options["memory"] + "g", (int)options["cores"], (int)options["nodeCount"]) : null
                };
                NotebookResource notebookResource = new NotebookResource(notebook);

                WriteObject(new PSNotebookResource(SynapseAnalyticsClient.CreateOrUpdateNotebook(this.Name, notebookResource), this.WorkspaceName));
            }
        }
    }
}
