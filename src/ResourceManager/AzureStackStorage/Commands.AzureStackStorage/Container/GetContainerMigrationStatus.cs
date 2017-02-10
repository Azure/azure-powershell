using System;
using System.Linq;
using System.Threading;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// SYNTAX
    /// Get-ACSContainerMigrationStatus  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-ShareName] {string} -Jobid {string} [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminContainerMigrationStatus)]
    public sealed class GetContainerMigrationStatus: AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public string SourceShareName { get; set;}

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6 )]
        public string JobId { get; set; }

        protected override void Execute()
        {
            MigrationResult response = this.Client.Shares.GetMigrationStatus(this.ResourceGroupName, this.FarmName, this.SourceShareName, this.JobId);
            this.WriteObject(response, true);
        }
    }
}
