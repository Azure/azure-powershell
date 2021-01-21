using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.DroppedSqlPool,
        DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSDroppedPoolBackupModel))]
    public class GetAzureSynapseDroppedSqlPool : SynapseManagementCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";

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
            HelpMessage = "The deletion date of the Azure Synaspe SQL Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)")]
        [ValidateNotNullOrEmpty]
        public DateTime? DeletionDate { get; set; }

        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                if (MyInvocation.BoundParameters.ContainsKey("DeletionDate"))
                {
                    var result = this.SynapseAnalyticsClient.GetDroppedSqlPoolBackup(this.ResourceGroupName, this.WorkspaceName, this.Name + "," + this.DeletionDate.Value.ToFileTimeUtc().ToString()).ConfigureAwait(true).GetAwaiter().GetResult();
                    WriteObject(result, true);
                }
                else
                {
                    var results = this.SynapseAnalyticsClient.ListDroppedSqlPoolBackups(this.ResourceGroupName, this.WorkspaceName).ConfigureAwait(true).GetAwaiter().GetResult().Where(backup => backup.SqlpoolName == Name).ToList();
                    WriteObject(results, true);
                }
            }
            else
            {
                var results = this.SynapseAnalyticsClient.ListDroppedSqlPoolBackups(this.ResourceGroupName, this.WorkspaceName).ConfigureAwait(true).GetAwaiter().GetResult();
                WriteObject(results, true);
            }
        }
    }
}