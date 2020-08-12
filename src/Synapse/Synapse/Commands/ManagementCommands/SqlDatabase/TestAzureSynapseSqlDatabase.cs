using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsDiagnostic.Test, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlDatabase, DefaultParameterSetName = TestByNameParameterSet)]
    [OutputType(typeof(bool))]
    public class TestAzureSynapseSqlDatabase : SynapseManagementCmdletBase
    {
        private const string TestByNameParameterSet = "TestByNameParameterSet";
        private const string TestByParentObjectParameterSet = "TestByParentObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = TestByNameParameterSet,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = TestByNameParameterSet,
            HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true,
            HelpMessage = HelpMessages.SqlDatabaseName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlDatabase,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = TestByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            WriteObject(SynapseAnalyticsClient.TestSqlDatabase(ResourceGroupName, WorkspaceName, Name));
        }
    }
}
