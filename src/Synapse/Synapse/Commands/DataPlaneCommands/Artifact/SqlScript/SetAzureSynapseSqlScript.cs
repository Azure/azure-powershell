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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript,
        "Import-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript)]
    [OutputType(typeof(PSSqlScriptResource))]
    public class SetAzureSynapseSqlScript : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";
        private const string SetByNameAndSqlPool = "SetByNameAndSqlPool";
        private const string SetByObjectAndSqlPool = "SetByObjectAndSqlPool";
        
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSqlPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObjectAndSqlPool,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSqlPool,
            Mandatory = true, HelpMessage = HelpMessages.SqlScriptSqlPoolName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndSqlPool,
            Mandatory = true, HelpMessage = HelpMessages.SqlScriptSqlPoolName)]
        [ValidateNotNullOrEmpty]
        public string SqlPoolName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndSqlPool,
        Mandatory = true, HelpMessage = HelpMessages.SqlScriptDatabaseName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObjectAndSqlPool,
        Mandatory = true, HelpMessage = HelpMessages.SqlScriptDatabaseName)]
        [ValidateNotNullOrEmpty]
        public string SqlDatabaseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.SqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("SqlScriptName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SqlFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string DefinitionFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ResultLimit)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = HelpMessages.DefaultResultLimit, Value = SynapseConstants.DefaultResultLimit)]
        public int ResultLimit { get; set; } = SynapseConstants.DefaultResultLimit;

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.SqlFolderPath)]
        [ValidateNotNullOrEmpty]
        [Alias("FolderName")]
        public string FolderPath { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Description)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

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

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseSqlScript, this.Name, this.WorkspaceName)))
            {
                string query = this.ReadFileAsText(DefinitionFile); 
                SqlConnection currentConnection = new SqlConnection();

                if (this.IsParameterBound(c => c.SqlPoolName))
                {                    
                    if(SqlPoolName.ToLower() == "built-in")
                    {
                        currentConnection.PoolName = "Built-in";
                        currentConnection.Type = SqlConnectionType.SqlOnDemand;
                        currentConnection.DatabaseName = this.SqlDatabaseName;
                    }
                    else
                    {
                        currentConnection.Type = SqlConnectionType.SqlPool;
                        currentConnection.PoolName = this.SqlPoolName;
                        currentConnection.DatabaseName = this.SqlDatabaseName;
                    }                
                }
                else
                {
                    currentConnection.PoolName = "Built-in";
                    currentConnection.Type = SqlConnectionType.SqlOnDemand;
                    currentConnection.DatabaseName = "master";
                }
                 
                SqlScriptMetadata metadata = new SqlScriptMetadata
                {
                    Language = "sql"
                };

                SqlScriptContent content = new SqlScriptContent(query);
                content.CurrentConnection = currentConnection;
                content.Metadata = metadata;
                content.ResultLimit = ResultLimit;

                SqlScript sqlscript = new SqlScript(content);
                sqlscript.Type = SqlScriptType.SqlQuery;
                if (this.IsParameterBound(c => c.FolderPath)) 
                {
                    SqlScriptFolder folder = new SqlScriptFolder();
                    folder.Name = FolderPath;
                    sqlscript.Folder = folder;
                }
                if (this.IsParameterBound(c => c.Description)) 
                {
                    sqlscript.Description = Description;
                }
                    
                SqlScriptResource sqlscriptResource = new SqlScriptResource(this.Name, sqlscript);

                WriteObject(new PSSqlScriptResource(SynapseAnalyticsClient.CreateOrUpdateSqlScript(this.Name, sqlscriptResource), this.WorkspaceName));
            }
        }

    }
}
