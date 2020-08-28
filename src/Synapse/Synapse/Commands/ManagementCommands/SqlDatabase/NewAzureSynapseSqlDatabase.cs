using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Management.Automation;
using Sku = Microsoft.Azure.Management.Synapse.Models.Sku;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlDatabase, DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlDatabase))]
    public class NewAzureSynapseSqlDatabase : SynapseManagementCmdletBase
    {
        // Default
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.SqlDatabaseName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [ValidateNotNullOrEmpty]
        public string Collation { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.MaxSizeInBytes)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.MaxSizeInBytes)]
        [ValidateNotNullOrEmpty]
        public long MaxSizeInBytes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            var existingWorkspace = this.SynapseAnalyticsClient.GetWorkspaceOrDefault(this.ResourceGroupName, this.WorkspaceName);
            if (existingWorkspace == null)
            {
                throw new SynapseException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            var existingSqlDatabase = this.SynapseAnalyticsClient.GetSqlDatabaseOrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
            if (existingSqlDatabase != null)
            {
                throw new SynapseException(string.Format(Resources.SynapseSqlDatabaseExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            var createParams = new SqlDatabase
            {
                Location = existingWorkspace.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            switch (this.ParameterSetName)
            {
                case CreateByNameParameterSet:
                case CreateByParentObjectParameterSet:
                    createParams.MaxSizeBytes = this.MaxSizeInBytes;
                    createParams.Collation = this.IsParameterBound(c => c.Collation) ? this.Collation : SynapseConstants.DefaultCollation;
                    break;

                default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSqlDatabase, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSqlDatabase(this.SynapseAnalyticsClient.CreateSqlDatabase(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
