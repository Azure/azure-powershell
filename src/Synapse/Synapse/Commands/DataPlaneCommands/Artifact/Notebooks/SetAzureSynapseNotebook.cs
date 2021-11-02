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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.NoteBookFolderPath)]
        [ValidateNotNullOrEmpty]
        public string FolderPath { get; set; }

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
        public int ExecutorCount { get; set; }

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

            if (!this.IsParameterBound(c => c.Name))
            {
                string path = this.TryResolvePath(DefinitionFile);
                this.Name = Path.GetFileNameWithoutExtension(path);
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseNotebook, this.Name, this.WorkspaceName)))
            {
                string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));
                Notebook notebook = JsonConvert.DeserializeObject<Notebook>(rawJsonContent);
                NotebookResource notebookResource = new NotebookResource(this.Name, notebook);

                if (this.IsParameterBound(c => c.SparkPoolName))
                {
                    NotebookMetadata metadata = notebookResource.Properties.Metadata;
                    var options = new ComputeOptions();

                    string suffix = DefaultContext.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
                    string endpoint = "https://" + this.WorkspaceName + "." + suffix;
                    var sparkPoolInfo = SynapseAnalyticsClient.GetBigDataPool(SparkPoolName);

                    options["auth"] = new ComputeOptions
                    {
                        ["type"] = "AAD",
                        ["authResource"] = DefaultContext.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId)
                    };
                    options["cores"] = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores;
                    options["memory"] = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory;
                    options["nodeCount"] = this.ExecutorCount;
                    options["endpoint"] = endpoint + "/livyApi/versions/" + SynapseConstants.SparkServiceEndpointApiVersion + "/sparkPools/" + this.SparkPoolName;
                    options["extraHeader"] = new ComputeOptions();
                    options["id"] = sparkPoolInfo.Id;
                    options["name"] = this.SparkPoolName;
                    options["sparkVersion"] = sparkPoolInfo.SparkVersion;
                    options["type"] = "Spark";
                    metadata.AdditionalProperties.Add("a365ComputeOptions", options);

                    notebookResource.Properties.BigDataPool = new BigDataPoolReference(BigDataPoolReferenceType.BigDataPoolReference, this.SparkPoolName);
                    notebookResource.Properties.SessionProperties = new NotebookSessionProperties(options["memory"] + "g", (int)options["cores"], options["memory"] + "g", (int)options["cores"], (int)options["nodeCount"]);
                }

                if (this.IsParameterBound(c => c.FolderPath))
                {
                    NotebookFolder folder = new NotebookFolder();
                    folder.Name = this.FolderPath;
                    notebookResource.Properties.Folder = folder;
                }

                WriteObject(new PSNotebookResource(SynapseAnalyticsClient.CreateOrUpdateNotebook(this.Name, notebookResource), this.WorkspaceName));
            }
        }
    }
}
