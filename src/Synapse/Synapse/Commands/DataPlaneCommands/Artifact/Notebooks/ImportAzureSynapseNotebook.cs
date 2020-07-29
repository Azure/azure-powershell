using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Commands.DataPlaneCommands.Artifact.Notebooks
{
    [Cmdlet(VerbsData.Import, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Notebook,
        DefaultParameterSetName = ImportByName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSNotebookResource))]
    public class ImportAzureSynapseNotebook : SynapseArtifactsCmdletBase
    {
        private const string ImportByName = "ImportByName";
        private const string ImportByObject = "ImportByObject";
        private const string ImportByNameAndSparkPool = "ImportByNameAndSparkPool";
        private const string ImportByObjectAndSparkPool = "ImportByObjectAndSparkPool";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ImportByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = ImportByObjectAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NotebookName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByObjectAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ValidateNotNullOrEmpty]
        public string SparkPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByNameAndSparkPool,
            Mandatory = false, HelpMessage = HelpMessages.ExecutorSize)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByObjectAndSparkPool,
            Mandatory = false, HelpMessage = HelpMessages.ExecutorSize)]
        [ValidateSet(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(Management.Synapse.Models.NodeSize.Small, Management.Synapse.Models.NodeSize.Medium, Management.Synapse.Models.NodeSize.Large)]
        public string ExecutorSize { get; set; } = Management.Synapse.Models.NodeSize.Small;

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByNameAndSparkPool,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ImportByObjectAndSparkPool,
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

                    notebookResource.Properties.BigDataPool = new BigDataPoolReference(new BigDataPoolReferenceType("BigDataPoolReference"), this.SparkPoolName);
                    notebookResource.Properties.SessionProperties = new NotebookSessionProperties(options["memory"] + "g", (int)options["cores"], options["memory"] + "g", (int)options["cores"], (int)options["nodeCount"]);
                }

                if (!this.IsParameterBound(c => c.Name))
                {
                    string path = this.TryResolvePath(DefinitionFile);
                    this.Name = path.Split('\\').Last().Split('.').First();
                }
                WriteObject(new PSNotebookResource(SynapseAnalyticsClient.CreateOrUpdateNotebook(this.Name, notebookResource), this.WorkspaceName));
            }
        }
    }
}
