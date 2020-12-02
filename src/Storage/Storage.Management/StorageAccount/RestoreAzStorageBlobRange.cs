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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobRange", SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSBlobRestoreStatus))]
    public class RestoreAzureStorageBlobRangeCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// Account ResourceId  parameter set 
        /// </summary>
        private const string AccountResourceIdParameterSet = "AccountResourceId";

        [Parameter(
         Position = 0,
         Mandatory = true,
         HelpMessage = "Resource Group Name.",
        ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Resource Id.",
           ParameterSetName = AccountResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Time to Restore Blob.")]
        [ValidateNotNull]
        public DateTime TimeToRestore { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The blob range to Restore.")]
        [ValidateNotNull]
        public PSBlobRestoreRange[] BlobRestoreRange { get; set; }

        [Parameter(HelpMessage = "Wait for Restore task complete")]
        public SwitchParameter WaitForComplete
        {
            get { return waitForComplete; }
            set { waitForComplete = value; }
        }
        private bool waitForComplete;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                case AccountResourceIdParameterSet:
                    ResourceIdentifier accountResource = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = accountResource.ResourceGroupName;
                    this.StorageAccountName = accountResource.ResourceName;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (ShouldProcess(this.StorageAccountName, "Restore Blob Range"))
            {
                if (waitForComplete)
                {                    
                    Task<AzureOperationResponse<BlobRestoreStatus>> beginTask = this.StorageClient.StorageAccounts.BeginRestoreBlobRangesWithHttpMessagesAsync(
                     this.ResourceGroupName,
                     this.StorageAccountName,
                     this.TimeToRestore,
                     PSBlobRestoreRange.ParseBlobRestoreRanges(this.BlobRestoreRange));

                    beginTask.Wait();

                    AzureOperationResponse<BlobRestoreStatus> response = beginTask.Result;

                    WriteWarning(string.Format("Restore blob ranges with Id '{0}' started. Restore blob ranges time to complete is dependent on the size of the restore.", response.Body is null ? "" : response.Body.RestoreId));

                    Task<AzureOperationResponse<BlobRestoreStatus>> waitTask = ((StorageManagementClient)this.StorageClient).GetPostOrDeleteOperationResultAsync(response, null, new System.Threading.CancellationToken());
                    try
                    {
                        waitTask.Wait();
                    }
                    catch (System.AggregateException ex) when (ex.InnerException is CloudException)
                    {
                        throw new InvalidJobStateException(string.Format("Blob ranges restore failed with information: '{0}'.", ((CloudException)ex.InnerException).Response.Content));
                    }

                    AzureOperationResponse<BlobRestoreStatus> result = waitTask.Result;

                    WriteObject(new PSBlobRestoreStatus(result.Body));

                }
                else
                {
                    BlobRestoreStatus status = this.StorageClient.StorageAccounts.BeginRestoreBlobRanges(
                     this.ResourceGroupName,
                     this.StorageAccountName,
                     this.TimeToRestore,
                     PSBlobRestoreRange.ParseBlobRestoreRanges(this.BlobRestoreRange));

                    WriteObject(new PSBlobRestoreStatus(status));
                    if (status != null && status.Status == BlobRestoreProgressStatus.Failed)
                    {
                        throw new InvalidJobStateException("Blob ranges restore failed.");
                    }
                }
            }
        }
    }
}
