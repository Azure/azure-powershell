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
    /// Get-ACSContainer [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-ShareName] {string} [[-Intent] {Migration}] [-Count {MaxCount}] [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminContainer)]
    public sealed class GetContainer : AdminCmdlet
    {
        /// <summary>
        /// Default value of records to be returned when count is not specified
        /// </summary>
        internal const uint DefaultMaxCountOfRecords = 10;
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
        public string ShareName { get; set;}

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = false, Position = 6 )]
        public ContainerGetIntent? Intent { get; set; }

        /// <summary>
        /// Storage Account Status
        /// </summary>
        [Parameter(Mandatory = false, Position = 7)]
        public uint? Count { get; set; }

        protected override void Execute()
        {
            if (null == this.Intent)
            {
                this.Intent = ContainerGetIntent.Migration;
            }

            if (null == this.Count)
            {
                this.Count = DefaultMaxCountOfRecords;
            }

            ContainerListResponse response = this.Client.Shares.GetContainers(this.ResourceGroupName, this.FarmName, this.ShareName, this.Intent.ToString(), this.Count.ToString());
            this.WriteObject(response, true);
        }
    }
}
