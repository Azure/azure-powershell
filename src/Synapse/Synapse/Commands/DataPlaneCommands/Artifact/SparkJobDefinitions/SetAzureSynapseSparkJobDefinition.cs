using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript,
        DefaultParameterSetName = SetByName, SupportsShouldProcess = true)]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript)]
    [OutputType(typeof(PSSqlScriptResource))]
    public class SetAzureSynapseSqlScript : SynapseArtifactsCmdletBase
    {
        private const string SetByName = "SetByName";
        private const string SetByObject = "SetByObject";
        private const string RenameByName = "RenameByName";
        private const string RenameByObject = "RenameByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RenameByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RenameByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("SqlScriptName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RenameByName,
            Mandatory = true, HelpMessage = HelpMessages.SqlScriptName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RenameByObject,
            Mandatory = true, HelpMessage = HelpMessages.SqlScriptName)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByName,
            Mandatory = true, HelpMessage = HelpMessages.ScriptFilePath)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByObject,
            Mandatory = true, HelpMessage = HelpMessages.ScriptFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias("File")]
        public string ScriptFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.SettingSynapseSqlScript, this.Name, this.WorkspaceName)))
            {
                switch (ParameterSetName)
                {
                    case SetByName:
                    case SetByObject:
                        string query = this.ReadFileAsText(this.TryResolvePath(ScriptFile));
                        SqlConnection connection = new SqlConnection(SqlConnectionType.SqlPool, )
                        SqlScriptContent sqlScriptContent = new SqlScriptContent(query, connection)
                        {
                            Metadata = new SqlScriptMetadata
                            {
                                Language = "sql"
                            }
                        };
                        SqlScript script = new SqlScript(content);
                        SqlScriptResource sqlScript = new SqlScriptResource(this.Name, new SqlScript)
                        {

                        }
                        WriteObject(new PSSqlScriptResource(SynapseAnalyticsClient.CreateOrUpdateSqlScript(this.Name, rawJsonContent)));
                        break;

                    case RenameByName:
                    case RenameByObject:
                        SynapseAnalyticsClient.RenameSqlScript(this.Name, this.NewName);
                        WriteObject(new PSSqlScriptResource(SynapseAnalyticsClient.GetSqlScript(this.Name)));
                        break;

                    default: throw new AzPSInvalidOperationException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
                }
            }
        }
    }
}
