using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DroppedSqlPool,
        DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSRestorableDroppedSqlPool))]
    public class GetAzureSynapseDroppedSqlPool : SynapseManagementCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.DeletionDate)]
        [ValidateNotNullOrEmpty]
        public DateTime? DeletionDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
                var result = this.SynapseAnalyticsClient.GetDroppedSqlPoolBackup(this.ResourceGroupName, this.WorkspaceName, this.Name);
                WriteObject(result);
                return;
            }

            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                if (MyInvocation.BoundParameters.ContainsKey("DeletionDate"))
                {
                    var result = this.SynapseAnalyticsClient.GetDroppedSqlPoolBackup(this.ResourceGroupName, this.WorkspaceName, this.Name + "," + this.DeletionDate.Value.ToFileTimeUtc().ToString());
                    WriteObject(result);
                }
                else
                {
                    var results = this.SynapseAnalyticsClient.ListDroppedSqlPoolBackups(this.ResourceGroupName, this.WorkspaceName).Where(backup => backup.DatabaseName == Name).ToList();
                    WriteObject(results, true);
                }
            }
            else
            {
                var results = this.SynapseAnalyticsClient.ListDroppedSqlPoolBackups(this.ResourceGroupName, this.WorkspaceName);
                WriteObject(results, true);
            }
        }
    }
}