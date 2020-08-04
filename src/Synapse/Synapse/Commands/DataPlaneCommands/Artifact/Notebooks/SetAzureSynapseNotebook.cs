using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        "Import-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook)]
    [OutputType(typeof(PSNotebookResource))]
    public class SetAzureSynapseNotebook : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";
        private const string SetByNameAndSparkPool = "SetByNameAndSparkPool";
        private const string SetByObjectAndSparkPool = "SetByObjectAndSparkPool";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObjectAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NotebookName)]
        [ValidateNotNullOrEmpty]
        [Alias("NotebookName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ValidateNotNullOrEmpty]
        public string SparkPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSparkPool,
            Mandatory = false, HelpMessage = HelpMessages.ExecutorSize)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndSparkPool,
            Mandatory = false, HelpMessage = HelpMessages.ExecutorSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string ExecutorSize { get; set; } = Management.Synapse.Models.NodeSize.Small;

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        public int Executors { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.JsonFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string DefinitionFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseNotebook, this.Name, this.WorkspaceName)))
            {
                string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));
                PSNotebook pSNotebook = JsonConvert.DeserializeObject<PSNotebook>(rawJsonContent);
                NotebookResource notebookResource = new NotebookResource(pSNotebook.ToSdkObject());

                if (this.IsParameterBound(c => c.SparkPoolName))
                {
                    NotebookMetadata metadata = notebookResource.Properties.Metadata;
                    var options = new ComputeOptions();

                    string suffix = DefaultContext.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
                    string endpoint = "https://" + this.WorkspaceName + "." + suffix;
                    var sparkPoolInfo = new SynapseAnalyticsManagementClient(DefaultContext).GetSparkPool(null, this.WorkspaceName, this.SparkPoolName);

                    options["auth"] = new ComputeOptions
                    {
                        ["type"] = "AAD",
                        ["authResource"] = DefaultContext.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId)
                    };
                    options["cores"] = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores;
                    options["memory"] = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory;
                    options["nodeCount"] = this.Executors;
                    options["endpoint"] = endpoint + "/livyApi/versions/" + SynapseConstants.SparkServiceEndpointApiVersion + "/sparkPools/" + this.SparkPoolName;
                    options["extraHeader"] = new ComputeOptions();
                    options["id"] = sparkPoolInfo.Id;
                    options["name"] = this.SparkPoolName;
                    options["sparkVersion"] = sparkPoolInfo.SparkVersion;
                    options["type"] = "Spark";
                    metadata["a365ComputeOptions"] = options;

                    notebookResource.Properties.BigDataPool = new BigDataPoolReference(BigDataPoolReferenceType.BigDataPoolReference, this.SparkPoolName);
                    notebookResource.Properties.SessionProperties = new NotebookSessionProperties(options["memory"] + "g", (int)options["cores"], options["memory"] + "g", (int)options["cores"], (int)options["nodeCount"]);
                }

                if (!this.IsParameterBound(c => c.Name))
                {
                    string path = this.TryResolvePath(DefinitionFile);
                    this.Name = Path.GetFileNameWithoutExtension(path);
                }
                WriteObject(new PSNotebookResource(SynapseAnalyticsClient.CreateOrUpdateNotebook(this.Name, notebookResource), this.WorkspaceName));
            }
        }
    }
}
