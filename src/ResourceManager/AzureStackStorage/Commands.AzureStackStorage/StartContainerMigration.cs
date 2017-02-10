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
    /// Start-ACSContainerMigration  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-ShareName] {string} [-Container] {container} [-DestinationShareName] {string} [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, Nouns.AdminContainerMigration)]
    public sealed class StartContainerMigration : AdminCmdlet
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
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public Container ContainerToMigrate { get; set; }

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6)]
        [ValidateNotNullOrEmpty]
        public string DestinationShareName { get; set;}

        protected override void Execute()
        {
            MigrationParameters migrationParameters = new MigrationParameters
                                                      {
                                                          ContainerName = this.ContainerToMigrate.ContainerName,
                                                          DestinationShareUncPath = this.DestinationShareName,
                                                          StorageAccountName = this.ContainerToMigrate.StorageAccountName
                                                      };

            var response = this.Client.Shares.MigrateContainer(this.ResourceGroupName, this.FarmName, this.ContainerToMigrate.ShareName, migrationParameters);
            //This should display the jobid from http header
            this.WriteObject(response, true);
        }
    }
}
 