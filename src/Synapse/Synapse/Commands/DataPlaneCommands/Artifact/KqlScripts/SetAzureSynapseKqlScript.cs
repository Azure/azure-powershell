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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.KqlScript,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.KqlScript,
        "Import-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.KqlScript)]
    [OutputType(typeof(PSKqlScriptResource))]
    public class SetAzureSynapseKqlScript : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";
        private const string SetByNameAndKustoPoolDatabase = "SetByNameAndKustoPoolDatabase";
        private const string SetByObjectAndKustoPoolDatabase = "SetByObjectAndKustoPoolDatabase";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObjectAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.KqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("KqlScriptName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.KustoPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.KustoPoolName)]
        [ValidateNotNullOrEmpty]
        public string KustoPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.KustoPoolDatabaseName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndKustoPoolDatabase,
            Mandatory = true, HelpMessage = HelpMessages.KustoPoolDatabaseName)]
        [ValidateNotNullOrEmpty]
        public string KustoPoolDatabaseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.KqlFilePath)]
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

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseKqlScript, this.Name, this.WorkspaceName)))
            {
                string query = this.ReadFileAsText(DefinitionFile);
                KqlScriptResource kqlScript = new KqlScriptResource
                {
                    Properties = new KqlScript
                    {
                        Content = new KqlScriptContent
                        {
                            Query = query,
                            Metadata = new KqlScriptContentMetadata
                            {
                                Language = "kql"
                            }
                        }
                    }
                };

                if (this.IsParameterBound(c => c.KustoPoolName))
                {
                    kqlScript.Properties.Content.CurrentConnection = new KqlScriptContentCurrentConnection
                    {
                        PoolName = this.KustoPoolName,
                        DatabaseName = this.KustoPoolDatabaseName
                    };
                }

                WriteObject(new PSKqlScriptResource(SynapseAnalyticsClient.CreateOrUpdateKqlScript(this.Name, kqlScript), this.WorkspaceName));
            }
        }
    }
}
