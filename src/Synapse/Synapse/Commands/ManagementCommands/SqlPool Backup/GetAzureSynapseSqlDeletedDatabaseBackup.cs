using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlDeletedDatabaseBackup,
        DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSDeletedDatabaseBackupModel))]
    public class GetAzureSynapseSqlDeletedDatabaseBackup : SynapseManagementCmdletBase
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
            ResourceTypes.SqlDeletedDatabaseBackup,
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
            ICollection<PSDeletedDatabaseBackupModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                if (MyInvocation.BoundParameters.ContainsKey("DeletionDate"))
                {
                    results = new List<PSDeletedDatabaseBackupModel>();
                    // The Sql pool expects a deleted database ID that consists of the database name and deletion time as a windows file time separated by a comma.
                    results.Add(this.SynapseAnalyticsClient.GetDeletedDatabaseBackup(this.ResourceGroupName, this.WorkspaceName, this.Name + "," + this.DeletionDate.Value.ToFileTimeUtc().ToString()).ConfigureAwait(true).GetAwaiter().GetResult());
                }
                else
                {
                    results = this.SynapseAnalyticsClient.ListDeletedDatabaseBackups(this.ResourceGroupName, this.WorkspaceName).ConfigureAwait(true).GetAwaiter().GetResult().Where(backup => backup.DatabaseName == Name).ToList();
                }
            }
            else
            {
                results = this.SynapseAnalyticsClient.ListDeletedDatabaseBackups(this.ResourceGroupName, this.WorkspaceName).ConfigureAwait(true).GetAwaiter().GetResult();
            }

            WriteObject(results, true);
        }
    }
}